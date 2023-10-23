using AppService;
using AppService.AdviceConsultingService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingBaseController : ControllerBase
    {
        internal readonly IAdviceConsultingService _consultingService;

        internal readonly IAuthService _authService;
        public AdviceConsultingBaseController (IAdviceConsultingService consultingService, IAuthService authService)
        {
            _consultingService = consultingService;
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
