using ApplicationService.MailSettings;
using AppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ConfigModels;

namespace BirdTrainingCenterAPI.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class TestServiceController : ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IMailService _mailService;
        private readonly IGoogleMapService _googleMapService;
        private readonly FirebaseBucket _bucket;
        private readonly GoogleConfig _googleConfig;
        public TestServiceController(IFirebaseService firebaseService, IMailService mailService, IGoogleMapService googleMapService, IOptions<FirebaseBucket> bucket)
        {
            _firebaseService = firebaseService;
            _mailService = mailService;
            _googleMapService = googleMapService;
            _bucket = bucket.Value;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost("firestore")]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            //for guidance used only
            var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TEST, _bucket.General);
            var delete = await _firebaseService.DeleteFile(temp, _bucket.General);
            return Ok(temp);
        }
        [HttpPost("mailsender")]
        public async Task<IActionResult> SendEmail(string receiverEmail, MailContent mailContent)
        {
            await _mailService.SendEmailAsync(receiverEmail, mailContent);
            return Ok();
        }
        [HttpGet("googlemap")]
        public async Task<IActionResult> TestGoogleMap(string destination)
        {
            try
            {
                var result = await _googleMapService.CalculateDistance(destination);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }                        
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFile(string fileUrl)
        {
            //for guidance used only
            var temp = await _firebaseService.DeleteFile(fileUrl, _bucket.General);
            return Ok(temp);
        }
    }
}
