using BS23Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BS23Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IConfiguration _configuration) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<IActionResult> Registration(UserRegistrationModel model)
        {
            if (ModelState.IsValid)
            {
                await model.OnPostAsync();
                var response = new RegistrationResponseModel { Username = model.UserName,
                    Message = "Congrats You have been Successfully Registered" };
                return Ok(response);
            }
            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if(await model.LoginAsync())
                {
                    var tokenConfig = _configuration.GetSection("TokenConfig").Get<TokenConfig>();
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, model.Username),
                        new Claim(ClaimTypes.Role, "Admin")
                    };
                    var token = tokenConfig!.GenerateToken(claims);
                    return Ok(new {token, model.Username});
                }
            }
            return BadRequest();
        }
    }
}