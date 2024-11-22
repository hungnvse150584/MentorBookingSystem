using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Repositories.Entities;
using Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MentorBookingManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _service;
        private IConfiguration _config;

        public UserController(UserService service, IConfiguration config)
        {
            _service = service;
            this._config = config;
        }
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var account = this._service.CheckLogin(request.Username, request.Password);
            if (account == null)
                return Unauthorized();

           

            var token = this.GenerateJSONWebToken(account);
            return Ok(token);
        }
        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              new Claim[]
              {
                  new(ClaimTypes.Email, userInfo.UserName),

                  new("userId", userInfo.UserId.ToString()),
              },
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials
              );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    
}
