using AppService;
using AppService.OnlineCourseService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BirdTrainingCenterAPI.Controllers.OnlineCourse
{
    [Route("api/online-course")]
    [ApiController]
    public class OnlineCourseBaseController : ODataController
    {
        internal readonly IOnlineCourseService _onlineCourseService;
        internal readonly IAuthService _authService;
        public OnlineCourseBaseController(IOnlineCourseService onlineCourseService, IAuthService authService)
        {
            _onlineCourseService = onlineCourseService;
            _authService = authService;
        }

    }
}
