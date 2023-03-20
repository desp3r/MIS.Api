using MIS.Api.Controllers.Base;

namespace MIS.Api.Controllers
{
    public class EmployeeController : BaseApiController
    {
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }
    }
}
