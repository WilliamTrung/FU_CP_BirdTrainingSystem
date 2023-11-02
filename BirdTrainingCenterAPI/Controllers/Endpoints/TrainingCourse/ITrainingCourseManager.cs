using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseManager : ITrainingCourseAll
    {
        [HttpPost]
        [Route("create")]
        Task<IActionResult> CreateCourse([FromForm] TrainingCourseAddParamModel trainingCourse);

        [HttpPut]
        [Route("edit")]
        Task<IActionResult> EditCourse([FromForm] TrainingCourseModParamModel trainingCourse);

        [HttpPut]
        [Route("disable")]
        Task<IActionResult> DisableTrainingCourse([FromQuery] int trainingCourseId);

        [HttpPost]
        [Route("add-skill")]
        Task<IActionResult> AddSkill([FromBody] AddTrainingSkillModel trainingCourseSkill);

        [HttpPut]
        [Route("active")]
        Task<IActionResult> ActiveTrainingCourse([FromQuery] int trainingCourseId);

        [HttpPost]
        [Route("birdspecies")]
        Task<IActionResult> CreateBirdSpecies([FromBody] BirdSpeciesAddModel birdSpecies);

        [HttpPut]
        [Route("birdspecies")]
        Task<IActionResult> EditBirdSpecies([FromBody] BirdSpeciesViewModel birdSpecies);
    }
}
