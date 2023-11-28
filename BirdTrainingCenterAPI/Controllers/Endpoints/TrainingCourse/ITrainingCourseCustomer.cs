using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseCustomer : ITrainingCourseAll
    {
        [HttpPost]
        [Route("register-bird")]
        Task<IActionResult> RegisterBird([FromForm] BirdAddParamModel bird);

        [HttpPut]
        [Route("update-bird")]
        Task<IActionResult> UpdateBirdProfile([FromForm] BirdModifyParamModel bird);

        [HttpGet]
        [Route("customer-bird")]
        Task<IActionResult> GetBirdByCustomerId(int customerId);

        [HttpGet]
        [Route("trainingcourse")]
        Task<IActionResult> GetTrainingCourse();

        [HttpGet]
        [Route("trainingcourse-species")]
        Task<IActionResult> GetTrainingCourseBySpeciesId([FromQuery] int birdSpeciesId);

        [HttpGet]
        [Route("trainingcourse-birdskill")]
        Task<IActionResult> GetTrainingCourseByBirdSkillId(int birdSkillId);

        [HttpGet]
        [Route("trainingcourse-birdspeciesskill")]
        Task<IActionResult> GetTrainingCourseBySpeciesIdBirdSkillId(int birdSpeciesId, int birdSkillId);

        [HttpGet]
        [Route("trainingcourse-id")]
        Task<IActionResult> GetTrainingCourseById([FromQuery] int trainingCourseId);

        [HttpPost]
        [Route("register-trainingcourse")]
        Task<IActionResult> RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister);

        [HttpGet]
        [Route("registered-trainingcourse")]
        Task<IActionResult> GetRegisteredTrainingCourse([FromQuery] int birdId, int customerId);

        [HttpGet]
        [Route("registered-birdtrainingcourseprogress")]
        Task<IActionResult> GetRegisteredBirdTrainingCourseProgress([FromQuery] int birdTrainingCourseId);

        [HttpGet]
        [Route("registered-birdtrainingcoursereport")]
        Task<IActionResult> GetRegisteredBirdTrainingCourseReport([FromQuery] int birdTrainingProgressId);

        [HttpGet]
        [Route("birdcertificate-requestedId")]
        Task<IActionResult> ViewCertificateByBirdTrainingCourseId(int birdTrainingCourseId);

        [HttpGet]
        [Route("birdcertificatepicture-requestedId")]
        Task<IActionResult> ViewCertificatePictureByBirdTrainingCourseId(int birdTrainingCourseId);

        [HttpGet]
        [Route("birdcertificate-birdId")]
        Task<IActionResult> ViewCertificateByBirdCertificateId(int birdId);
    }
}
