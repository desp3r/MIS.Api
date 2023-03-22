using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Schedule;
using MIS.Business.Models.Speciality;

namespace MIS.Api.Controllers
{
    public class SpecialityController : BaseApiController
    {
        private readonly ILogger<SpecialityController> _logger;

        public SpecialityController(ILogger<SpecialityController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Speciality.CRUD)]
        public async Task<IActionResult> Create([FromBody] SpecialityModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Speciality.CRUD)]
        public async Task<IActionResult> Update([FromBody] SpecialityModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Speciality.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Speciality.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Speciality.List)]
        public async Task<IActionResult> List([FromQuery] ListSpecialityRequest request)
        {
            return Ok();

        }
    }
}
