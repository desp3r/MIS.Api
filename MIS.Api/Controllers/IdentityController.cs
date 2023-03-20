
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Interfaces;
using MIS.Business.Models.User;

namespace Mis.Api.Controllers
{
    public class IdentityController : BaseApiController
    {
        private readonly ILogger<IdentityController> _logger;
        private readonly IIdentityService _identityService;

        public IdentityController(
            ILogger<IdentityController> logger, 
            IIdentityService identityService)
        {
            _logger = logger;
            _identityService = identityService;
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterUserRequest request)
        {
            try
            {
                var result = await _identityService.RegisterUserAsync(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw ex;
            }
        }

        [AllowAnonymous]
        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginUserRequest request)
        {
            var result = await _identityService.LoginUserAsync(request);
            return Ok(result);
        }
    }
}
