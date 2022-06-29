using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.WebAPI.Data;
using GagerApp.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GagerApp.WebAPI.Controllers
{
    [Authorize]
    public class ClientsController : ControllerBase
    {
        private readonly IUserService _userService;

        public ClientsController(IUserService userService, IMapper mapper, DataContext context)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        private readonly IMapper _mapper;
        private readonly DataContext _context;

        [Route(EndPoints.Clients.Get)]
        [HttpGet()]
        public async Task<IActionResult> GetClientAsync([FromQuery] int? orderId)
        {
            if (orderId is null)
            {
                return Forbid();
            }

            var queryable = _context.ZayavkaZamer.AsQueryable();
            var order = queryable.FirstOrDefault(x => x.IdZayavka == orderId);
            if (order == null)
            {
                return NotFound();
            }
            var clients = _context.CounterpartyDirectory.AsQueryable();
            var client = await clients.FirstOrDefaultAsync(x => x.IdCustomerDirectoryNavigation.IdCustomerDirectory == order.IdPartnerNavigation.IdCustomerDirectory);
            if (client == null)
            {
                return NotFound();
            }
            var clientDTO = _mapper.Map<ClientDTO>(client);
            return Ok(clientDTO);
        }

    }
}
