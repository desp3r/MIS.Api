using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Appointment;
using MIS.Business.Models.User;

namespace MIS.Api.Controllers
{
    public class AppointmentController : BaseApiController
    {
        private readonly ILogger<AppointmentController> _logger;

        public AppointmentController(ILogger<AppointmentController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Appointment.CRUD)]
        public async Task<IActionResult> Create([FromBody] AppointmentModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Appointment.CRUD)]
        public async Task<IActionResult> Update([FromBody] AppointmentModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Appointment.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Appointment.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Appointment.List)]
        public async Task<IActionResult> List([FromQuery] ListAppointmentRequest request)
        {
            return Ok();

        }
    }
}
