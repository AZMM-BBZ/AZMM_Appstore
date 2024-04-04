using AZMM.Server.DtoModel;
using Microsoft.AspNetCore.Mvc;

namespace AZMM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet("getCurrentUser")]
        public ActionResult<UserDto> GetCurrentUser()
        {
            var userClaim = this.User.Claims;
            var userDto = new UserDto();
            //userDto.Uid = userClaim.ElementAt(0).Value;
            //userDto.Username = userClaim.ElementAt(1).Value;
            //userDto.Permission = userClaim.ElementAt(3).Value;
            //userDto.Role = userClaim.ElementAt(4).Value;
            return Ok(userDto);
        }

        [HttpPost("addUser")]
        public ActionResult AddUser([FromBody] UserDto newUser)
        {
            return Ok();
        }

        [HttpPost("updateUser")]
        public ActionResult UpdateUser([FromBody] UserDto user)
        {
            return Ok();
        }

        [HttpPost("deleteUser")]
        public ActionResult DeleteUser([FromBody] UserDto user)
        {
            return Ok();
        }
    }
}
