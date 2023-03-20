
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MIS.Api.Controllers.Base;
using MIS.Business.Interfaces;
using MIS.Business.Models.User;
using MIS.Data.Models;

namespace Mis.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;

        public UserController(
            ILogger<UserController> logger,
            IUserService userService)
        {
            _logger = logger;
            userService = userService;
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.User.GetInfo + "{Id}")]
        public HttpResponseMessage GetInfo(int Id)
        {
            userService.GetInfo(Id);
            return null; //temporary
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.User.Appointment)]
        public HttpResponseMessage CreateAppointment(Appointment appointment)
        {
            userService.CreateAppointment(appointment);
            return null; //temporary
        }

        [AllowAnonymous]
        [HttpGet(ApiRoutes.User.Appointment)]
        public HttpResponseMessage GetAppointment()
        {
            userService.GetAppointment();
            return null; //temporary
        }

    }
}

