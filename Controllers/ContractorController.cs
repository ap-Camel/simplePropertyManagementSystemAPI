using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace simplePropertyManagementSystemAPI.Controllers {

    [ApiController]
    [Route("amnesty")]
    [Authorize]
    public class ContractorController : ControllerBase {

    }
}