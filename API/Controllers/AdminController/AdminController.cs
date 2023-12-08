using Application.Dtos;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        public static Admin admin = new Admin();
        private readonly IConfiguration _configuration;

        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("register")]
        public ActionResult<Admin> Register(AdminDto request)
        {
            string password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            admin.Username = request.Username;
            admin.Password = password;

            return Ok(admin);
        }

        [HttpPost("login")]
        public ActionResult<Admin> Login(AdminDto request)
        {
            if (admin.Username != request.Username)
            {
                return BadRequest("User not found");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, admin.Password))
            {
                return BadRequest("Password is wrong!");
            }

            string token = GenerateJWTToken(admin);
            return Ok(token);
        }

        private string GenerateJWTToken(Admin admin)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, admin.Username),
                new Claim(ClaimTypes.Role, "Admin"),
            };

            var key = Encoding.ASCII.GetBytes(
                _configuration["JWTToken:Token"]!);


            var token = new JwtSecurityToken
            (
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
