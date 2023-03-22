using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Appointment;
using MIS.Business.Models.Organization;

namespace MIS.Api.Controllers
{
    public class OrganizationController : BaseApiController
    {
        private readonly ILogger<OrganizationController> _logger;

        public OrganizationController(ILogger<OrganizationController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Organization.CRUD)]
        public async Task<IActionResult> Create([FromBody] OrganizationModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Organization.CRUD)]
        public async Task<IActionResult> Update([FromBody] OrganizationModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Organization.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Organization.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Organization.List)]
        public async Task<IActionResult> List([FromQuery] ListOrganizationRequest request)
        {
            return Ok();

        }
    }
}
