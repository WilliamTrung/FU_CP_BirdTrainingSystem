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
        private readonly FirebaseBucket _bucket;
        public TestServiceController(IFirebaseService firebaseService, IMailService mailService, IOptions<FirebaseBucket> bucket)
        {
            _firebaseService = firebaseService;
            _mailService = mailService;
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
        [HttpDelete]
        public async Task<IActionResult> DeleteFile(string fileUrl)
        {
            //for guidance used only
            var temp = await _firebaseService.DeleteFile(fileUrl, _bucket.General);
            return Ok(temp);
        }
    }
}
