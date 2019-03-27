using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BackendApi.Data;
using BackendApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BackendApi.Controllers
{
    [Route("api/[controller]/[action]")]

   // [Route("/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return BadRequest("Enter your username and password");
            try
            {
                using (var context = new RecordsContext())
                {
                    var exists = context.Users.Any(n => n.UserName == user.UserName && n.Password == user.Password);
                    if (exists) return Ok(CreateToken(user));

                    return BadRequest("Wrong credentials");
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                using (var context = new RecordsContext())
                {
                    var exists = context.Users.Any(n => n.UserName == user.UserName);
                    if (exists) return BadRequest("User already exists");

                    context.Users.Add(user);
                    context.SaveChanges();

                    return Ok(CreateToken(user));
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        private JwtPackage CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //var claims = new ClaimsIdentity(new[] {new Claim(ClaimTypes.Email, user.UserName)});
            //const string secretKey = "laura";
            //var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
            //var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384Signature);

            var token = tokenHandler.CreateJwtSecurityToken();
                //subject: claims,
                //signingCredentials: signingCredentials
               // );

            var tokenString = tokenHandler.WriteToken(token); 

            return new JwtPackage()
            {
                UserName = user.UserName,
                Token = tokenString
            };
        }
    }

    public class JwtPackage
    {
        public string Token { get; set; }
        public string UserName { get; set; }
    }
}