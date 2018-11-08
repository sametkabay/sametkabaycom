using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SametKabay.Application.UserServices;
using SametKabay.Application.UserServices.Dto;

namespace SametKabayApi.Controllers
{
    /// <summary>
    /// User Controller
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppServices _userAppServices;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userAppServices"></param>
        /// <param name="mapper"></param>
        public UserController(IUserAppServices userAppServices, IMapper mapper)
        {
            _userAppServices = userAppServices;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        //[Authorize(Policy = "AdminOnly")]
        public IActionResult CreateUser(CreateUserInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _userAppServices.CreateUser(model);
            return Ok();
        }

        /// <summary>
        /// Login Method
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await _userAppServices.Login(model);
            return Ok(token);
        }
    }
}