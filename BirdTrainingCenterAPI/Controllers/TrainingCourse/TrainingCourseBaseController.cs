using AppService.TrainingCourseService;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse")]
    [ApiController]
    public class TrainingCourseBaseController : ControllerBase
    {
        internal readonly ITrainingCourseService _trainingCourseService;
        public TrainingCourseBaseController(ITrainingCourseService trainingCourseService)
        {
            _trainingCourseService = trainingCourseService;
        }
    }
}
