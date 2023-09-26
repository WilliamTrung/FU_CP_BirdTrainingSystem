using AppService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ConfigModels;

namespace BirdTrainingCenterAPI.Controllers
{
    [Route("api/upload")]
    [ApiController]
    public class TestUploadController : ControllerBase
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public TestUploadController(IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> PostFiles(IFormFile file)
        {
            //for guidance used only
            var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.TEST, _bucket.General);
            return Ok(temp);
        }
    }
}
