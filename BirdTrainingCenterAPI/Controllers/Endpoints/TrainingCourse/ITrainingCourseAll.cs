using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseAll
    {
        [HttpGet]
        [Route("birdspecies-id")]
        Task<IActionResult> GetBirdSpeciesById([FromQuery] int birdSpeciesId);

        [HttpGet]
        [Route("birdspecies")]
        Task<IActionResult> GetBirdSpecies();

        [HttpGet]
        [Route("trainingcourse")]
        Task<IActionResult> GetTrainingCourses();

        [HttpGet]
        [Route("trainingcourse-id")]
        Task<IActionResult> GetTrainingCoursesById(int courseId);

        //[HttpGet]
        //[Route("trainingcourseskill-courseid")]
        //Task<IEnumerable<TrainingSkillViewModel>> GetTrainingSkillByCourseId(int courseId);

        [HttpGet]
        [Route("birdtrainingprogress-statuses")]
        IActionResult GetEnumBirdTrainingProgressStatuses();
    }
}
