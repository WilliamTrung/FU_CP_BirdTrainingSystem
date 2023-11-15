using ApplicationService.MailSettings;
using AppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ConfigModels;
using SP_Extension;

namespace BirdTrainingCenterAPI.Controllers
{
    [Route("api/addon")]
    [ApiController]
    public class AddonServiceController : ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        private readonly IMailService _mailService;
        private readonly IGoogleMapService _googleMapService;
        private readonly FirebaseBucket _bucket;
        public AddonServiceController(IFirebaseService firebaseService, IMailService mailService, IGoogleMapService googleMapService, IOptions<FirebaseBucket> bucket)
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
        [HttpPost("upload")]
        public async Task<IActionResult> PostFile(IFormFile file)
        {
            //for guidance used only
            string url = string.Empty;
            if (file.IsImage())
            {
                if(file.Length > 5 * 1024 * 1024)
                {
                    return BadRequest("Image too large!");
                }
                url = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.IMAGE, _bucket.General);
            } else if(file.IsVideo())
            {
                url = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.VIDEO, _bucket.General);
            } else
            {
                url = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TEST, _bucket.General);
            }
            if(url != string.Empty)
            {
                return Ok(url);
            } else
            {
                return BadRequest("Not an image or video");
            }
            
            //var delete = await _firebaseService.DeleteFile(temp, _bucket.General);
            //return Ok(temp);
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
        //[HttpDelete]
        //public async Task<IActionResult> DeleteFile(string fileUrl)
        //{
        //    //for guidance used only
        //    var temp = await _firebaseService.DeleteFile(fileUrl, _bucket.General);
        //    return Ok(temp);
        //}
    }
}
