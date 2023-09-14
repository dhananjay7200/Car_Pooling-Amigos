using Car_pooling.Interfaces;
using Car_pooling.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;

namespace Car_pooling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailsController : ControllerBase
    {
        private IUserDetails _IUser;

        public UserDetailsController(IUserDetails iUser)
        {
            _IUser = iUser;
        }

        [HttpPost]
        public async Task<ActionResult> UserLoginAsync(LoginDetails user)
        {
            string data = await _IUser.UserLogin(user);
            if(data.Equals("not found"))
            {
                return NotFound();
            }
            return Ok(new Tokens { Token = data });

        }

        [HttpPost("/register")]
        public async Task<ActionResult> RegisterUser(UserDetail user) {
            UserDetail data=await _IUser.UserRegister(user);
            if (data == null)
            {
                return BadRequest();
            }
            return Ok(data);
        }


    }
}
