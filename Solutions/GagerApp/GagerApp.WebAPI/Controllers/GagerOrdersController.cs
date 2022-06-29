using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using AutoMapper;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using GagerApp.WebApi.Utils.DateTimeModelBinder;
using GagerApp.WebAPI.Data;
using GagerApp.WebAPI.Helpers;
using GagerApp.WebAPI.Models;
using GagerApp.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GagerApp.WebAPI.Controllers
{
    [Authorize()]
    public class GagerOrdersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GagerOrdersController(IUserService userService, IMapper mapper, DataContext context)
        {
            _userService = userService;
            _mapper = mapper;
            _context = context;
        }

        [Route(EndPoints.GagerOrders.Get)]
        [HttpGet()]
        public async Task<IActionResult> GetAsync([FromQuery][DateTimeModelBinder] DateTime? date)
        {
            if (date is null)
            {
                return Forbid();
            }

            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

          
            var queryable = _context.ZayavkaZamer.AsQueryable();
            var queryableUser = _context.UserProfile.AsQueryable();
            UserProfile user = await queryableUser.FirstOrDefaultAsync(x => x.IdUser == userId);
               var orders = await queryable.Where(x => x.IdProfileWorker == user.IdProfileWorker && x.DateZamer == date).Include(x => x.Id).ToListAsync();

            var ordersResponse = _mapper.Map<List<OrderDTO>>(orders);

            return Ok(ordersResponse);
        }

        [Route(EndPoints.GagerOrders.GetFull)]
        [HttpGet()]
        public async Task<IActionResult> GetFullOrderAsync([FromRoute] int orderNumber)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var queryable = _context.ZayavkaZamer.AsQueryable()
                .Include(x => x.IdProfileWorkerNavigation)
                .Include(x => x.IdStatusZamerNavigation)
                .Include(x => x.IdPartnerNavigation)
                .ThenInclude(x => x.CatalogTelNumber)
                .Include(x => x.Id)
                .ThenInclude(x => x.CatalogRoom);
            var order = await queryable.FirstOrDefaultAsync(x => x.IdZayavka == orderNumber);
            if (order == null)
            {
                return NotFound();
            }

            var fullorderResponse = _mapper.Map<FullOrderDTO>(order);

            return Ok(fullorderResponse);
        }

        [Route(EndPoints.GagerOrders.UpdateStatus)]
        [HttpPut()]
        public async Task<IActionResult> UpdateStatusAsync([FromBody] UpdateOrderStatusRequest updateStatusRequest)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null) 
            {
                return Unauthorized();
            }

            var zayavka = await _context.ZayavkaZamer.FirstOrDefaultAsync(x => x.IdZayavka == updateStatusRequest.OrderID);
            if (zayavka == null)
            {
                return NotFound();
            }

            zayavka.IdStatusZamer = (int)updateStatusRequest.Status;
            
            _context.ZayavkaZamer.Update(zayavka);
            var updated = await _context.SaveChangesAsync();
            if (updated == 0)
            {
                return NotFound();
            }

            return Ok(zayavka);
        }

        [Route(EndPoints.GagerOrders.Delete)]
        [HttpDelete]
        public async Task<IActionResult> DeleteZamerAsync([FromRoute] int orderNumber)
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var queryable = _context.ZayavkaZamer.AsQueryable();
            var order = await queryable.FirstOrDefaultAsync((z) => z.IdZayavka == orderNumber);

            if (order is null)
            {
                return NotFound();
            }
            var delete = _context.ZayavkaZamer.Remove(order);
            var updated = await _context.SaveChangesAsync();
            return updated == 0 ? NotFound() : (IActionResult)Ok();
        }
    }
}
