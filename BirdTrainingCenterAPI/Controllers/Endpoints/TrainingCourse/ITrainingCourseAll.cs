using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;

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

        [HttpPost]
        [Route("birdskillreceived")]
        Task<IActionResult> CreateBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel);

        [HttpDelete]
        [Route("birdskillreceived")]
        Task<IActionResult> DeleteBirdSkillReceived(BirdSkillReceivedAddDeleteModel addDeleteModel);

        [HttpGet]
        [Route("birdcertificatedetail")]
        Task<IActionResult> GetBirdCertificatesDetail();

        [HttpGet]
        [Route("birdcertificatedetail-bird")]
        Task<IActionResult> GetBirdCertificatesDetailByBirdId(int birdId);

        [HttpGet]
        [Route("birdskillreceived")]
        Task<IActionResult> GetBirdSkillReceiveds();

        [HttpGet]
        [Route("birdskillreceived-bird")]
        Task<IActionResult> GetBirdSkillReceivedsByBirdId(int birdId);

        [HttpGet]
        [Route("trainerskill")]
        Task<IActionResult> GetTrainerSkills();

        [HttpGet]
        [Route("trainerskill-trainerid")]
        Task<IActionResult> GetTrainerSkillsByTrainerId(int trainerId);

        [HttpGet]
        [Route("trainableskill")]
        Task<IActionResult> GetTrainableSkills();

        [HttpGet]
        [Route("birdskill")]
        Task<IActionResult> GetBirdSkills();

        [HttpGet]
        [Route("birdskill-id")]
        Task<IActionResult> GetBirdSkillsById(int birdSkillId);

        [HttpGet]
        [Route("skill")]
        Task<IActionResult> GetSkills();

        [HttpGet]
        [Route("skill-id")]
        Task<IActionResult> GetSkillById(int skillId);

        [HttpGet]
        [Route("accquirablebirdskill")]
        Task<IActionResult> GetAccquirableBirdSkill();

        [HttpGet]
        [Route("accquirablebirdskill-birdspecies")]
        Task<IActionResult> GetAccquirableBirdSkillByBirdSpeciesId(int birdSpeciesId);

        [HttpGet]
        [Route("bird-receivedskill")]
        Task<IActionResult> ViewBirdSkillReceived(int birdId);
    }
}
