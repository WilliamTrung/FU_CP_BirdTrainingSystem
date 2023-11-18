using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.TrainingCourse;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse
{
    public interface ITrainingCourseStaff : ITrainingCourseAll
    {
        [HttpGet]
        [Route("birdtrainingcourse")]
        Task<IActionResult> GetBirdTrainingCourse();

        [HttpGet]
        [Route("birdtrainingcourse-bird")]
        Task<IActionResult> GetBirdTrainingCourseByBirdId([FromQuery] int birdId);

        [HttpGet]
        [Route("birdtrainingcourse-customer")]
        Task<IActionResult> GetBirdTrainingCourseByCustomerId(int customerId);

        //[HttpPost]
        //[Route("confirm-birdtrainingcourse")]
        //Task ConfirmBirdTrainingCourse(int birdTrainingCourseId);

        [HttpGet]
        [Route("birdtrainingprogress-requestedId")]
        Task<IActionResult> GetBirdTrainingCourseProgressByBirdTrainingCourseId([FromQuery] int birdTrainingCourseId);

        [HttpGet]
        [Route("trainer")]
        Task<IActionResult> GetTrainer();

        [HttpGet]
        [Route("trainer-birdskill")]
        Task<IActionResult> GetTrainerByBirdSkillId([FromQuery] int birdSkillId);

        [HttpPost]
        [Route("trainer-id")]
        Task<IActionResult> GetTrainerById([FromQuery] int trainerId);

        [HttpPost]
        [Route("trainer-skill")]
        Task<IActionResult> GetTrainerByTrainerSkillId([FromQuery] int trainerSkillId);

        //[HttpPost]
        //[Route("generate-trainerslot")]
        //Task<IActionResult> GenerateTrainerTimetable([FromBody] IEnumerable<int> progressId);

        [HttpPut]
        [Route("receive-bird")]
        Task<IActionResult> ReceiveBird([FromForm] ReceiveBirdParamModel birdTrainingCourse);

        [HttpPut]
        [Route("return-bird")]
        Task<IActionResult> ReturnBird([FromForm] ReturnBirdParamModel birdTrainingCourse);

        [HttpPost]
        [Route("birdtrainingcourse-confirm")]
        Task<IActionResult> ConfirmBirdTrainingCourse(int birdTrainingCourseId);

        //[HttpPost]
        //[Route("generatedprogresstimetable-confirm")]
        //Task<IActionResult> Generatedprogresstimetable(List<int> birdTrainingProgressId);

        [HttpPost]
        [Route("birdtrainingcourse-cancel")]
        Task<IActionResult> CancelBirdTrainingCourse(int birdTrainingCourseId);

        [HttpGet]
        [Route("birdtrainingreport-progressid")]
        Task<IActionResult> GetReportByProgressId(int progressId);

        [HttpPut]
        [Route("assigntrainertoprogress")]
        Task<IActionResult> AssignTrainer(int progressId, int trainerId);

        [HttpPut]
        [Route("trainerslot-modify")]
        Task<IActionResult> ModifyTrainingSlot(ReportModifyModel reportModModel);

        //[HttpPost]
        //[Route("birdcertificatedetail")]
        //Task<IActionResult> CreateBirdCertificateDetail(BirdCertificateDetailAddModel birdCertificateDetailAdd);
    }
}
