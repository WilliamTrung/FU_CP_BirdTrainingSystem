using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseManager
    {
        [HttpPost]
        [Route("create")]
        Task<IActionResult> CreateCourse([FromBody] TrainingCourseModel trainingCourse);

        [HttpPut]
        [Route("edit")]
        Task<IActionResult> EditCourse([FromBody] TrainingCourseModel trainingCourse);

        [HttpPut]
        [Route("disable")]
        Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId);

        [HttpPost]
        [Route("add-skill")]
        Task<IActionResult> AddSkill([FromBody] TrainingCourseSkillModel trainingCourseSkill);

        [HttpPut]
        [Route("active")]
        Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId);
    }
}
