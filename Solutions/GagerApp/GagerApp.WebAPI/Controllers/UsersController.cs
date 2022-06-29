using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GagerApp.Model;
using GagerApp.Model.DTO;
using GagerApp.Model.Entities;
using GagerApp.WebAPI.Data;
using GagerApp.WebAPI.Helpers;
using GagerApp.WebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GagerApp.WebAPI.Controllers
{
    [Authorize()]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;


        public UsersController(IUserService userService, IMapper mapper, DataContext dataContext)

        {
            _userService = userService;
            _mapper = mapper;
            _dataContext = dataContext;
        }

        [AllowAnonymous]
        [Route(EndPoints.Users.Login)]
        [HttpPost()]
        public async Task<IActionResult> LoginAsync([FromBody] AuthenticateRequest model)
        {
            var response = await _userService.LoginAsync(model);

            if (!response.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Errors = response.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Token = response.Token,
                RefreshToken = response.RefreshToken
            });
        }

        [Route(EndPoints.Users.Get)]
        [HttpGet()]
        public async Task<IActionResult> GetAsync()
        {
            var userId = HttpContext.GetUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

           

            var user = await _userService.GetByIdAsync(userId.Value);

            var userResponse = _mapper.Map<UserDTO>(user);
          
            return Ok(userResponse);
        }

        [AllowAnonymous]
        [Route(EndPoints.Users.Refresh)]
        [HttpPost()]
        public async Task<IActionResult> RefreshAsync([FromBody] RefreshTokenRequest model)
        {
            var response = await _userService.RefreshTokenAsync(model.Token, model.RefreshToken);

            if (response == null)
            {
                return BadRequest(new
                {
                    message = "Tokens combination is invalid"
                });
            }

            return Ok(response);
        }


    }
}
