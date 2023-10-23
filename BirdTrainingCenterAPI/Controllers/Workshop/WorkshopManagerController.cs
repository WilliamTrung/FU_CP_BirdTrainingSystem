using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.Workshop;
using Models.ConfigModels;
using Models.ServiceModels.WorkshopModels;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopManagerController : WorkshopBaseController, IWorkshopManager
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public WorkshopManagerController(IWorkshopService workshopService, IAuthService authService, IFirebaseService firebaseService, FirebaseBucket bucket) : base(workshopService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWorkshop([FromForm] WorkshopAddParamModel workshop)
        {
            try
            {
                var pictures = string.Empty;
                foreach (var file in workshop.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.WOKRSHOP, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var workshopAdd = workshop.ToWorkshopAddModel(pictures);
                await _workshopService.Manager.CreateWorkshop(workshopAdd);
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }
        [HttpGet]
        [Route("detail-template")]
        public async Task<IActionResult> GetWorkshopDetailTemplate([FromQuery] int workshopId)
        {
            try
            {
                var result = await _workshopService.Manager.GetDetailTemplatesByWorkshopId(workshopId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet]
        [Route("status")]
        public async Task<IActionResult> GetWorkshopStatuses()
        {
            var result = await _workshopService.Manager.GetWorkshopStatuses();
            return Ok(result);
        }
        [HttpPut]
        [Route("modify-detail-template")]
        public async Task<IActionResult> ModifyWorkshopDetail([FromBody] WorkshopDetailTemplateModiyModel workshopDetail)
        {
            try
            {
                await _workshopService.Manager.ModifyWorkshopDetailTemplate(workshopDetail);
                return Ok();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("modify-status")]
        public async Task<IActionResult> ModifyWorkshopStatus([FromBody] WorkshopStatusModifyModel workshop)
        {
            try
            {
                await _workshopService.Manager.ModifyWorkshopStatus(workshop);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
