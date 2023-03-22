using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Speciality;
using MIS.Business.Models.Timeslot;

namespace MIS.Api.Controllers
{
    public class TimeslotController : BaseApiController
    {
        private readonly ILogger<TimeslotController> _logger;

        public TimeslotController(ILogger<TimeslotController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Timeslot.CRUD)]
        public async Task<IActionResult> Create([FromBody] TimeslotModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Timeslot.CRUD)]
        public async Task<IActionResult> Update([FromBody] TimeslotModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Timeslot.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Timeslot.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Timeslot.List)]
        public async Task<IActionResult> List([FromQuery] ListTimeslotRequest request)
        {
            return Ok();

        }
    }
}
