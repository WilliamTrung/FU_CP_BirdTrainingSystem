using AppService;
using AppService.WorkshopService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [Route("api/workshop")]
    [ApiController]
    public class WorkshopBaseController : ControllerBase
    {
        internal readonly IWorkshopService _workshopService;
        internal readonly IAuthService _authService;

        public WorkshopBaseController(IWorkshopService workshopService, IAuthService authService)
        {
            _workshopService = workshopService;
            _authService = authService;
        }
        internal List<Claim>? DeserializeToken()
        {
            var authHeader = Request.Headers["Authorization"];
            if (authHeader.Count == 0 || !authHeader[0].StartsWith("Bearer "))
            {
                return null;
            }
            string accessToken = authHeader[0].Split(' ')[1];
            return _authService.DeserializedToken(accessToken);
        }
    }
}
