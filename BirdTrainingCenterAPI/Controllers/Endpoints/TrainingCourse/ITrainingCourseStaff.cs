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
