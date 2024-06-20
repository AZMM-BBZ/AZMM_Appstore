using AZMM.Server.DtoModel;
using AZMM.Server.Services.Interfaces;
using Froghopper.Context;
using Froghopper.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AZMM.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getCurrentUser")]
        public ActionResult<UserDto> GetCurrentUser()
        {
            var user = _userService.GetCurrentUser();

            var userClaim = this.User.Claims;
            var userDto = new UserDto();
            userDto.Uid = user.Uid;
            userDto.Name = user.Name;
            userDto.Password = user.Password;

            //userDto.Uid = int.Parse(userClaim.ElementAt(0).Value);
            //userDto.Name = userClaim.ElementAt(1).Value;
            //userDto.Password = userClaim.ElementAt(2).Value;
            return Ok(userDto);
        }

        [HttpPost("updateUser")]
        public ActionResult UpdateUser([FromBody] UserDto userDto)
        {
            var user = new User { Name = userDto.Name, Password = userDto.Password };
            var result = _userService.UpdateUser(user);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("deleteUser")]
        public ActionResult DeleteUser([FromBody] UserDto userDto)
        {
            var user = new User { Name = userDto.Name, Password = userDto.Password };
            var result = _userService.DeleteUser(user);
            if (result)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
