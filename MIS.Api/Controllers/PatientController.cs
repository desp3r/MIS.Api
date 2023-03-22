using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Organization;
using MIS.Business.Models.Patient;

namespace MIS.Api.Controllers
{
    public class PatientController : BaseApiController
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Patient.CRUD)]
        public async Task<IActionResult> Create([FromBody] PatientModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Patient.CRUD)]
        public async Task<IActionResult> Update([FromBody] PatientModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Patient.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Patient.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Patient.List)]
        public async Task<IActionResult> List([FromQuery] ListPatientRequest request)
        {
            return Ok();

        }
    }
}
