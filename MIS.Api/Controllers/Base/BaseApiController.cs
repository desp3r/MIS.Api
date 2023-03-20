using Microsoft.AspNetCore.Mvc;
using System.Web.Http;

namespace MIS.Api.Controllers.Base
{
    [Authorize]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
