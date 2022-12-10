using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using simplePropertyManagementSystemAPI.Dtos.SystemUserDtos;
using simplePropertyManagementSystemAPI.Models;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Controllers {

    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase {

        private readonly ISystemUserData systemUserData;
        private readonly IConfiguration config;

        public AuthController(ISystemUserData systemUserData, IConfiguration config){
            this.systemUserData = systemUserData;
            this.config = config;
        }


        [HttpPost]
        public async Task<ActionResult<SystemUserLoginReturnDto>> loginAsync(SystemUserLoginDto user) {
            
            SystemUser systemUserVerify = await systemUserData.verifyUserAsync(user.email, user.password);

            if(systemUserVerify is null) {
                return NotFound("invalid credentials");
            }

            try
            {
                return new SystemUserLoginReturnDto {
                    systemUser = new SystemUserEssentialsDto {
                        firstName = systemUserVerify.firstName,
                        lastName = systemUserVerify.lastName,
                        email = systemUserVerify.email
                        },
                    JWT = generateToken(systemUserVerify)
                };
            }
            catch (System.Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
                throw;
            }
        }



        private string generateToken(SystemUser user) {
             List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, $"{user.firstName} {user.lastName}"),
                new Claim("ID", user.ID.ToString()),
                new Claim(ClaimTypes.Email, user.email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["AppSettings:Token"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                        claims: claims,
                        expires: DateTime.UtcNow.AddDays(60),
                        signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}