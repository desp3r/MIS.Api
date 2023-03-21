using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Models.User;

namespace MIS.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.User.CRUD)]
        public async Task<IActionResult> Create([FromBody] UserModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPut(ApiRoutes.User.CRUD)]
        public async Task<IActionResult> Update([FromBody] UserModel model)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpDelete(ApiRoutes.User.CRUD)]
        public async Task<IActionResult> Delete([FromBody] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.User.CRUD)]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.User.List)]
        public async Task<IActionResult> List([FromQuery] ListUserRequest request)
        {
            return Ok();
        }
    }
}
