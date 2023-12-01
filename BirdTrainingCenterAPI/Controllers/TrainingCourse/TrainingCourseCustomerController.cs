using AppService;
using AppService.TrainingCourseService;
using BirdTrainingCenterAPI.Controllers.Endpoints.TrainingCourse;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.TrainingCourse;
using Models.AuthModels;
using Models.ConfigModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate.BirdCertificateDetail;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using TEST_CERTSAMPLE;

namespace BirdTrainingCenterAPI.Controllers.TrainingCourse
{
    [Route("api/trainingcourse-customer")]
    [ApiController]
    //[CustomAuthorize(roles: "Customer")]
    public class TrainingCourseCustomerController : TrainingCourseBaseController, ITrainingCourseCustomer
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        private readonly IPdfGenerator _pdf;
        public TrainingCourseCustomerController(ITrainingCourseService trainingCourseService, IAuthService authService, IFirebaseService firebaseService, IPdfGenerator pdf, IOptions<FirebaseBucket> bucket) : base(trainingCourseService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
            _pdf = pdf;
        }
        [HttpPost]
        [Route("register-bird")]
        public async Task<IActionResult> RegisterBird([FromForm] BirdAddParamModel bird)
        {
            var pictures = string.Empty;
            if(bird.Picture != null)
            {
                if (!bird.Picture.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                string fileName = $"{nameof(BirdModel)}-{bird.Name}-{bird.CustomerId}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(bird.Picture, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                pictures += $"{temp},";

                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            else
            {
                pictures = null;
            }
            var birdModel = bird.ToBirdAddModel(pictures);

            var result = await _trainingCourseService.Customer.RegisterBird(birdModel);
            return Ok(result);
        }
        [HttpPost]
        [Route("update-bird")]
        public async Task<IActionResult> UpdateBirdProfile([FromForm] BirdModifyParamModel bird)
        {
            var pictures = string.Empty;
            if (bird.Picture != null)
            {
                if (!bird.Picture.IsImage())
                {
                    return BadRequest("Upload image only!");
                }
                string fileName = $"{nameof(BirdModel)}-{bird.Name}-{bird.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(bird.Picture, fileName, FirebaseFolder.TRAININGCOURSE, _bucket.General);
                pictures += $"{temp},";

                pictures = pictures.Substring(0, pictures.Length - 1);
            }
            else
            {
                pictures = null;
            }
            var birdModel = bird.ToBirdModifyModel(pictures);

            await _trainingCourseService.Customer.UpdateBirdProfile(birdModel);
            return Ok();
        }
        [HttpGet]
        [Route("customer-bird")]
        public async Task<IActionResult> GetBirdByCustomerId([FromQuery] int customerId)
        {
            //var accessToken = Request.DeserializeToken(_authService);
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            //else
            //{
            //    var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            //    var result = await _trainingCourseService.Customer.GetBirdByCustomerId(Int32.Parse(customerId.Value));
            //    return Ok(result);
            //}
            var result = await _trainingCourseService.Customer.GetBirdByCustomerId(customerId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse")]
        public async Task<IActionResult> GetTrainingCourse()
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourse();
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-species")]
        public async Task<IActionResult> GetTrainingCourseBySpeciesId([FromQuery] int birdSpeciesId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseBySpeciesId(birdSpeciesId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-birdskill")]
        public async Task<IActionResult> GetTrainingCourseByBirdSkillId([FromQuery] int birdSkillId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseByBirdSkillId(birdSkillId);
            return Ok(result);
        }

        [HttpGet]
        [Route("trainingcourse-birdspeciesskill")]
        public async Task<IActionResult> GetTrainingCourseBySpeciesIdBirdSkillId([FromQuery] int birdSpeciesId, [FromQuery] int birdSkillId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseBySpeciesIdBirdSkillId(birdSpeciesId: birdSpeciesId, birdSkillId: birdSkillId);
            return Ok(result);
        }
        [HttpGet]
        [Route("trainingcourse-id")]
        public async Task<IActionResult> GetTrainingCourseById([FromQuery] int trainingCourseId)
        {
            var result = await _trainingCourseService.Customer.GetTrainingCourseById(trainingCourseId);
            return Ok(result);
        }
        [HttpPost]
        [Route("register-trainingcourse")]
        public async Task<IActionResult> RegisterTrainingCourse([FromBody] BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            await _trainingCourseService.Customer.RegisterTrainingCourse(birdTrainingCourseRegister);
            return Ok();
        }
        [HttpGet]
        [Route("registered-birdtrainingcourse")]
        public async Task<IActionResult> GetRegisteredTrainingCourse([FromQuery] int birdId, [FromQuery] int customerId)
        {
            //var accessToken = Request.DeserializeToken(_authService);
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            //else
            //{
            //    var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

            //    var result = await _trainingCourseService.Customer.ViewRegisteredTrainingCourse(birdId: birdId, customerId: Int32.Parse(customerId.Value));
            //    return Ok(result);
            //}
            var result = await _trainingCourseService.Customer.ViewRegisteredTrainingCourse(birdId: birdId, customerId: customerId);
            return Ok(result);
        }
        [HttpGet]
        [Route("registered-birdtrainingcourseprogress")]
        public async Task<IActionResult> GetRegisteredBirdTrainingCourseProgress([FromQuery] int birdTrainingCourseId)
        {
            var result = await _trainingCourseService.Customer.ViewBirdTrainingCourseProgress(birdTrainingCourseId);
            return Ok(result);
        }
        [HttpGet]
        [Route("registered-birdtrainingcoursereport")]
        public async Task<IActionResult> GetRegisteredBirdTrainingCourseReport([FromQuery] int birdTrainingProgressId)
        {
            var result = await _trainingCourseService.Customer.ViewBirdTrainingCourseReport(birdTrainingProgressId);
            return Ok(result);
        }

        [HttpGet]
        [Route("birdcertificate-requestedId")]
        public async Task<IActionResult> ViewCertificateByBirdTrainingCourseId(int birdTrainingCourseId)
        {
            var result = await _trainingCourseService.Customer.ViewCertificateByBirdTrainingCourseId(birdTrainingCourseId);
            return Ok(result);
        }

        [HttpGet]
        [Route("birdcertificate-birdId")]
        public async Task<IActionResult> ViewCertificateByBirdCertificateId(int birdId)
        {
            var result = await _trainingCourseService.Customer.ViewCertificateByBirdId(birdId);
            return Ok(result);
        }
        [HttpGet]
        [Route("birdcertificatepicture-requestedId")]
        public async Task<IActionResult> ViewCertificatePictureByBirdTrainingCourseId(int birdTrainingCourseId)
        {
            var birdCerti = await _trainingCourseService.Customer.ViewCertificateByBirdTrainingCourseId(birdTrainingCourseId);
            if(birdCerti == null)
            {
                return BadRequest("Not found certificate");
            }
            else
            {
                var certiPdf = _pdf.GenerateCertificate(birdCerti.BirdName, birdCerti.BirdCertificateViewModel.Title, birdCerti.ReceiveDate);
                //var base64Object = Convert.ToBase64String(certiPdf);
                //return Ok(base64Object);
                return File(certiPdf, "application/pdf");
            }
        }
        [HttpGet]
        [Route("birdcertificatepicture-requestedId-base64")]
        public async Task<IActionResult> ViewCertificatePictureByBirdTrainingCourseIdBase64(int birdTrainingCourseId)
        {
            var birdCerti = await _trainingCourseService.Customer.ViewCertificateByBirdTrainingCourseId(birdTrainingCourseId);
            if (birdCerti == null)
            {
                return BadRequest("Not found certificate");
            }
            else
            {
                var certiPdf = _pdf.GenerateCertificate(birdCerti.BirdName, birdCerti.BirdCertificateViewModel.Title, birdCerti.ReceiveDate);
                var base64Object = Convert.ToBase64String(certiPdf);
                return Ok(base64Object);
                //return File(certiPdf, "application/pdf");
            }
        }
    }
}
