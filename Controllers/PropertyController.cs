
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using simplePropertyManagementSystemAPI.Dtos.PropertyDtos;
using simplePropertyManagementSystemAPI.Helpers;
using simplePropertyManagementSystemAPI.Models;
using simplePropertyManagementSystemAPI.Services.LocalDb.Interfaces;

namespace simplePropertyManagementSystemAPI.Controllers {

    [ApiController]
    [Route("property")]
    [Authorize]
    public class PropertyController : ControllerBase {

        private readonly IPropertyData propertyData;

        public PropertyController(IPropertyData propertyData) {
            this.propertyData = propertyData;
        }


        [HttpGet]
        public async Task<ActionResult<List<PropertyEssentialsDto>>> getPropertiesAsync() {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await propertyData.getPropertiesAsync(userID);

            if(result.Count() == 0) {
                return NotFound("no properties found");
            }

            List<PropertyEssentialsDto> temp = new List<PropertyEssentialsDto>();
            foreach(Property p in result) {
                temp.Add(Converting.toPropertyEssentials(p));
            }

            return Ok(temp);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyEssentialsDto>> getPropertyAsync(int id) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await propertyData.getPropertyByPropertyIdAsync(id, userID);

            return result is not null ? Ok(result) : NotFound("no property was found");
        }


        [HttpPost]
        public async Task<ActionResult> insertPropertyAsync(PropertyInsertDto property) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await propertyData.insertPropertyAsync(property, userID);

            return result > 0 ? CreatedAtAction(nameof(getPropertyAsync), new {id = result}, null) : BadRequest("property was not added ");
        }


        [HttpPut]
        public async Task<ActionResult<bool>> updatePropertyAsync(PropertyUpdateDto property) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await propertyData.updatePropertyAsync(property, userID);

            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest("failed to edit the property");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> deletePropertyAsync(int id) {

            int userID = JwtHelpers.getGeneralID(HttpContext.Request.Headers["Authorization"]);

            var result = await propertyData.deletePropertyAsync(id, userID);

            return result ? StatusCode(StatusCodes.Status204NoContent) : BadRequest("failed to delete the property");
        }
    }
}