using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManagement.Model;
using UserManagement.Service;

namespace UserManagement.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getUserDetails")]
        public async Task<JsonResult> GetUserDetailsAsync()
        {
            var result = await _userService.GetUserDetailsAsync();
            return new JsonResult(result);
            //return await Task.Run(() => new JsonResult(HttpStatusCode.BadGateway));
        }

        [HttpPost]
        [Route("saveUserDetails")]
        public async Task<ActionResult> SaveUserDetailsAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = await _userService.SaveUserDetailsAsync(user);
            return result == 1 ? Ok("Success") : BadRequest("Not Success");
        }

        [HttpPut]
        [Route("updateUserDetails")]
        public async Task<ActionResult> UpdateUserDetailsAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var result = await _userService.UpdateUserDetailsAsync(user);
            return result == 1 ? Ok("Success") : BadRequest("Not Success");
        }

        [HttpPut]
        [Route("deleteUserDetails/{userId:Int}")]
        public async Task<ActionResult> DeleteUserDetailsAsync(int userId)
        {
            if (userId < 1)
            {
                throw new ArgumentException(nameof(userId));
            }

            var result = await _userService.DeleteUserDetailsAsync(userId);
            return result == 1 ? Ok("Success") : BadRequest("Not Success");
        }

        [HttpGet]
        [Route("getUserDetailsById")]
        public async Task<JsonResult> GetUserDetailsByIdAsync(IEnumerable<int> userId)
        {
            var result = await _userService.GetUserDetailsByIdAsync(userId);
            return new JsonResult(result);
            //return await Task.Run(() => new JsonResult(HttpStatusCode.BadGateway));
        }
    }
}
