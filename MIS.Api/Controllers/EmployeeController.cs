using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.Employee;
using MIS.Business.Models.User;

namespace MIS.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Create([FromBody] EmloyeeModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Update([FromBody] EmloyeeModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Employee.List)]
        public async Task<IActionResult> List([FromQuery] ListEmployeesRequest request)
        {
            return Ok();
        }
    }
}
