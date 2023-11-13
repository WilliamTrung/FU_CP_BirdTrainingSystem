using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
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
    }
}
