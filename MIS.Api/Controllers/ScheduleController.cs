using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Patient;
using MIS.Business.Models.Schedule;

namespace MIS.Api.Controllers
{
    public class ScheduleController : BaseApiController
    {
        private readonly ILogger<ScheduleController> _logger;

        public ScheduleController(ILogger<ScheduleController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Schedule.CRUD)]
        public async Task<IActionResult> Create([FromBody] ScheduleModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Schedule.CRUD)]
        public async Task<IActionResult> Update([FromBody] ScheduleModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Schedule.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Schedule.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Schedule.List)]
        public async Task<IActionResult> List([FromQuery] ListScheduleRequest request)
        {
            return Ok();

        }
    }
}
