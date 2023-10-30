using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseManager
    {
        [HttpPost]
        [Route("create")]
        Task<IActionResult> CreateCourse([FromForm] TrainingCourseParamModel trainingCourse);

        [HttpPut]
        [Route("edit")]
        Task<IActionResult> EditCourse([FromForm] TrainingCourseParamModel trainingCourse);

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
