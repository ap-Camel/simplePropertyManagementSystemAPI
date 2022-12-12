using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using simplePropertyManagementSystemAPI.Dtos.TenantDtos;
using simplePropertyManagementSystemAPI.Helpers;
using simplePropertyManagementSystemAPI.Models;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Controllers {

    [Route("tenant")]
    [ApiController]
    [Authorize]
    public class TenantController : ControllerBase {
        
        private readonly ITenantData tenantData;

        public TenantController(ITenantData tenantData) {
            this.tenantData = tenantData;
        }


        [HttpGet]
        public async Task<ActionResult<List<TenantEssentialsDto>>> getTenantsAsync() {
            
            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await tenantData.getTenantsAsync(userID);

            if(result.Count() == 0) {
                return NotFound("no tenants were found");
            }

            List<TenantEssentialsDto> temp = new List<TenantEssentialsDto>();
            foreach(Tenant p in result) {
                temp.Add(new TenantEssentialsDto {
                    ID = p.ID,
                    firstName = p.firstName,
                    lastName = p.lastName,
                    contactNumber = p.contactNumber,
                    email = p.email,
                    IdNumber = p.IdNumber,
                    nationality = p.nationality,
                    tenantDescription = p.tenantDescription,
                    tenantStatus = p.tenantStatus,
                    dateAdded = p.dateAdded,
                    dateUpdated = p.dateUpdated,
                    propertyID = p.propertyID
                });
            }

            return Ok(temp);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TenantEssentialsDto>> getTenantAsync(int id) {
            
            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await tenantData.getTenantAsync(id, userID);

            return result is not null ? Ok(result) : NotFound("no tenant was found");
        }


        [HttpPost]
        public async Task<ActionResult> insertTenantAsync(TenantInsertDto tenant) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await tenantData.insertTenantAsync(tenant, userID);

            return result > 0 ? CreatedAtAction(nameof(getTenantAsync), new {id = result}, null) : BadRequest("tenant was not added ");
        }


        [HttpPut]
        public async Task<ActionResult<bool>> updateTenantAsync(TenantUpdateDto tenant) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await tenantData.updateTenantAsync(tenant, userID);

            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest("failed to edit the tenant");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deleteTenantAsync(int id) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await tenantData.deleteTenantAsync(id, userID);

            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest("failed to delete the tenant");
        }
    }
}