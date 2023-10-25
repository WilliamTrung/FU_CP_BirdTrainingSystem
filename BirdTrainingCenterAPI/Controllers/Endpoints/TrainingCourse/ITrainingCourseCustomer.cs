using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseCustomer
    {
        [HttpPost]
        [Route("register-bird")]
        Task<IActionResult> RegisterBird([FromBody]BirdModel bird);

        [HttpPut]
        [Route("update-bird")]
        Task<IActionResult> UpdateBirdProfile(BirdModel bird);

        [HttpGet]
        [Route("customer-bird")]
        Task<IActionResult> GetBirdByCustomerId([FromQuery]int customerId);

        [HttpGet]
        [Route("trainingcourse")]
        Task<IActionResult> GetTrainingCourse();

        [HttpGet]
        [Route("trainingcourse-species")]
        Task<IActionResult> GetTrainingCourseBySpeciesId([FromQuery] int birdSpeciesId);

        [HttpGet]
        [Route("trainingcourse-id")]
        Task<IActionResult> GetTrainingCourseById([FromQuery] int trainingCourseId);

        [HttpPost]
        [Route("register-trainingcourse")]
        Task<IActionResult> RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);

        [HttpGet]
        [Route("registered-trainingcourse")]
        Task<IActionResult> GetRegisteredTrainingCourse([FromQuery] int birdId,[FromQuery] int customerId);

        [HttpGet]
        [Route("registered-birdtrainingcourseprogress")]
        Task<IActionResult> GetRegisteredBirdTrainingCourseProgress([FromQuery] int birdTrainingCourseId);

        [HttpGet]
        [Route("registered-birdtrainingcoursereport")]
        Task<IActionResult> GetRegisteredBirdTrainingCourseReport([FromQuery] int birdTrainingProgressId);
    }
}
