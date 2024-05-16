using AZMM.Server.DtoModel;
using AZMM.Server.Services.Interfaces;
using Froghopper.models;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AZMM.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private ILogger<AuthenticationController> _logger;
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger, IUserService userService, IConfiguration configuration)
        {
            _logger = logger;
            _userService = userService;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public ActionResult<string> Authenticate([FromBody] AuthenticationRequestBody authenticationRequestBody)
        {
            var user = _userService.GetUserFromDatabase(authenticationRequestBody.Username, authenticationRequestBody.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var securityKey =
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("userid", user.Uid.ToString()));
            claimsForToken.Add(new Claim("username", user.Name));
            claimsForToken.Add(new Claim("password", user.Password));
            claimsForToken.Add(new Claim(JwtClaimTypes.Role, user.Role.RoleName));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddMinutes(30),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            _logger.LogInformation("New JWT Token: " + tokenToReturn);
            return Ok(tokenToReturn);
        }
    }
}
