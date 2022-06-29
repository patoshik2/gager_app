using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.WebAPI.Data;
using GagerApp.WebAPI.Helpers;
using GagerApp.WebAPI.Models;
using GagerApp.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GagerApp.WebAPI.Controllers
{
    [Authorize()]
    public class RoomsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public RoomsController(IUserService userService, IMapper mapper, DataContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        [Route(EndPoints.Rooms.Get)]
        [HttpGet()]
        public async Task<IActionResult> GetRoomsAsync([FromQuery] int? orderId)
        {
            if (orderId is null)
            {
                return Forbid();
            }

            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var queryable = _context.ZayavkaZamer.AsQueryable().Include(x => x.Id).ThenInclude(x => x.CatalogRoom);
            ICollection<Models.CatalogRoom> rooms = (await queryable.FirstOrDefaultAsync(x => x.IdZayavka == orderId))?.Id.CatalogRoom;
            if (rooms == null)
            {
                return NotFound();
            }
            /*foreach (var room in rooms)
            {
              var fullRoom =  _context.CatalogRoom.AsQueryable()
                    .Include(room => room.IdConstructNavigation).ThenInclude(construct => construct.PriceVidConstruct)
                    .Include(room => room.PositionSmeta)
            }*/
            var roomsDTOResponse = _mapper.Map<List<RoomDTO>>(rooms);

            return Ok(roomsDTOResponse);
        }

        [Route(EndPoints.Rooms.GetCost)]
        [HttpGet()]
        public async Task<IActionResult> GetRoomsCostAsync([FromRoute] int roomNumber)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var dateQueryable = _context.CatalogRoom.AsQueryable().Include(room => room.IdZayavkaNavigation);
            DateTime? zayavkaDate = (await dateQueryable.FirstOrDefaultAsync(fullRoom => fullRoom.IdRoom == roomNumber))?.IdZayavkaNavigation.DateZamer;

            if (zayavkaDate == null)
            {
                return NotFound();
            }

            var queryable = _context.CatalogRoom.AsQueryable()
                .Include(x => x.IdConstructNavigation).ThenInclude(x => x.PriceVidConstruct)
                .Include(room => room.PositionSmeta).ThenInclude(position => position.IdCatalogNavigation).ThenInclude(matusl => matusl.PriceMatUsl);
            CatalogRoom room = await queryable.FirstOrDefaultAsync(x => x.IdRoom == roomNumber);
            if (room == null)
            {
                return NotFound();
            }
            var constructCost = (room.IdConstructNavigation.PriceVidConstruct.Where(cost => cost.DateCost <= zayavkaDate).OrderBy(cost => cost.DateCost).LastOrDefault()?.Cost).GetValueOrDefault();
            constructCost = constructCost == default ? 0 : constructCost;
            /* var smetaQueryable = _context.PriceMatUsl.AsQueryable().Include(price => price.IdCatalogNavigation).ThenInclude(cat =>cat.PositionSmeta).ThenInclude(position => position.Id);
             var smeta = smetaQueryable.Where(price => price.IdCatalogNavigation.PositionSmeta.)*/

            var smetaTotal = room.PositionSmeta
                .Select(position => position.Col * position.IdCatalogNavigation.PriceMatUsl
                .Where(cost => cost.Date <= zayavkaDate)
                .OrderBy(cost => cost.Date)
                .LastOrDefault()?.Cost ?? 0)
                .Sum();

            return Ok(constructCost + smetaTotal);
        }

        [Route(EndPoints.Rooms.GetFull)]
        [HttpGet()]
        public async Task<IActionResult> GetFullRoomAsync([FromRoute] int roomNumber)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }
            var queryable = _context.CatalogRoom.AsQueryable()
                .Include(x => x.IdConstructNavigation).ThenInclude(x => x.PriceVidConstruct)
                .Include(room => room.PositionSmeta).ThenInclude(position => position.IdCatalogNavigation).ThenInclude(matusl => matusl.PriceMatUsl)
                .Include(room => room.PositionSmeta).ThenInclude(position => position.IdCatalogNavigation).ThenInclude(x => x.IdTypeMatUslNavigation)
                .Include(room => room.PositionSmeta).ThenInclude(position => position.IdCatalogNavigation).ThenInclude(x => x.IdUnitsNavigation);
            CatalogRoom fullroom = await queryable.FirstOrDefaultAsync(x => x.IdRoom == roomNumber);
            if (fullroom == null)
            {
                return NotFound();
            }
            
            var fullRoomsDTOResponse = _mapper.Map<FullRoomDTO>(fullroom);
            return Ok(fullRoomsDTOResponse);
        }

        [Route(EndPoints.Rooms.Create)]
        [HttpPost]
        public async Task<IActionResult> CreateRoomAsync([FromBody] Model.Entities.CreateRoomRequest request)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var queryable = _context.ZayavkaZamer.AsQueryable();
            var queryableUser = _context.UserProfile.AsQueryable();
            UserProfile user = await queryableUser.FirstOrDefaultAsync(x => x.IdUser == userId);
            var zayavka = await queryable.FirstOrDefaultAsync((z) => z.IdProfileWorker == user.IdProfileWorker && z.IdZayavka == request.OrderID);

            if (zayavka is null)
            {
                return NotFound();
            }

            var firstVidConstruct = await _context.CatalogVidConstruct.FirstOrDefaultAsync();
            if (firstVidConstruct == null)
            {
                //TODO: need to inform technical staff of data inconsistency
                return Problem();
            }

            var result = _context.CatalogRoom.Add(new CatalogRoom()
            {
                NameRoom = request.RoomName,
                IdAdress = zayavka.IdAdress,
                IdPartner = zayavka.IdPartner,
                IdZayavka = zayavka.IdZayavka,
                IdConstruct = firstVidConstruct.IdConstruct
            }
            );
            var updated = await _context.SaveChangesAsync();
            if (updated == 0)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RoomDTO>(result.Entity));
        }

        [Route(EndPoints.Rooms.Delete)]
        [HttpDelete]
        public async Task<IActionResult> DeleteRoomAsync([FromRoute] int roomNumber)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var queryable = _context.CatalogRoom.AsQueryable();
            var room = await queryable.FirstOrDefaultAsync((z) => z.IdRoom == roomNumber);

            if (room is null)
            {
                return NotFound();
            }
            var delete =  _context.CatalogRoom.Remove(room);
            var updated = await _context.SaveChangesAsync();
            return updated == 0 ? NotFound() : (IActionResult)Ok();
        }
    }
}
