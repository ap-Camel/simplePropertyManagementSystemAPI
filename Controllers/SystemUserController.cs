using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using simplePropertyManagementSystemAPI.Dtos.SystemUserDtos;
using simplePropertyManagementSystemAPI.Helpers;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Controllers {

    [ApiController]
    [Route("systemUser")]
    public class SystemUserController : ControllerBase {

        private readonly ISystemUserData systemUserData;

        public SystemUserController(ISystemUserData systemUserData) {
            this.systemUserData = systemUserData;
        }

        

        [HttpPost]
        public async Task<ActionResult<bool>> SignupAsync(SystemUserSignupDto user) {

            var verifyEmail = await systemUserData.verifyEmailAsync(user.email);
            if(verifyEmail is not null) {
                return Conflict("user with this email already exists");
            }

            string pssHash = await Hashing.hash(user.userPassword);

            int result = await systemUserData.insertUserAsync(user, pssHash);

            return result > 0 ? Created(nameof(getUserDataAsync), user) : BadRequest("user was not found");

        }


        [HttpGet]
        [Authorize]
        public async Task<ActionResult<SystemUserEssentialsDto>> getUserDataAsync() {


            int id = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            if(id <= 0) {
                return NotFound("no user with this id exists");
            }

            var systemUser = await systemUserData.getSystemUserByIdAsync(id);

            if(systemUser is null) {
                return NotFound("no user with this id exists");
            }

            return Ok(new SystemUserEssentialsDto {
                firstName = systemUser.firstName,
                lastName = systemUser.lastName,
                email = systemUser.email
                });
        }
    }
}