using AppService.TrainingCourseService;
using AppService.TrainingSkillService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ConfigModels;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/training-skill/management")]
    [CustomAuthorize(roles: "Manager")]
    [ApiController]
    public class TrainingSkillController : ControllerBase
    {
        private readonly ITrainingSkillService _trainingSkill;
        public TrainingSkillController(ITrainingSkillService trainingSkill)
        {
            _trainingSkill = trainingSkill;
        }
        [HttpDelete]
        [Route("acquirable-skill")]
        public async Task<IActionResult> DeleteAcquirableSkill([FromBody] AcquirableAddModBirdSkill model)
        {            
            await _trainingSkill.Extra.DeleteAcquirableSkill(model);
            return Ok();
        }
    }
}
