using AppService;
using AppService.TimetableService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [Route("api/timetable")]
    [ApiController]
    public class TimetableBaseController : ODataController
    {
        internal readonly ITimetableService _timetableService;
        internal readonly IAuthService _authService;
        public TimetableBaseController(ITimetableService timetableService, IAuthService authService)
        {
            _timetableService = timetableService;
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
