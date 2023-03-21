using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Interfaces;
using MIS.Business.Models.Employee;
using MIS.Business.Models.User;

namespace MIS.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeService _employeeService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }


        [AllowAnonymous]
        [HttpPost(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Create([FromBody] EmloyeeModel model)
        {
            var result = await _employeeService.CreateAsync(model);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Update([FromBody] EmloyeeModel model)
        {
            var result = await _employeeService.UpdateAsync(model);
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            var result = await _employeeService.DeleteAsync(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Employee.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            var result = await _employeeService.GetAsync(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.Employee.List)]
        public async Task<IActionResult> List([FromQuery] ListEmployeesRequest request)
        {
            var result = await _employeeService.ListAsync(request);
            return Ok(result);
        }
    }
}
