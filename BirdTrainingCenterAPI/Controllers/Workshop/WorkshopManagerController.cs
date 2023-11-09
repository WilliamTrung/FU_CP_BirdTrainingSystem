using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Options;
using MimeKit;
using Models.ApiParamModels.Workshop;
using Models.ConfigModels;
using Models.ServiceModels.WorkshopModels;
using SP_Middleware;
using System.Net.Mime;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [CustomAuthorize(roles: "Manager")]
    public class WorkshopManagerController : WorkshopBaseController, IWorkshopManager
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public WorkshopManagerController(IWorkshopService workshopService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(workshopService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateWorkshop([FromForm] WorkshopAddParamModel workshop)
        {
            var pictures = string.Empty;
            try
            {
                if(workshop.Pictures.Any(e => !e.IsImage())) {
                    return BadRequest("Upload image only!");
                }
                foreach (var file in workshop.Pictures)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.WOKRSHOP, _bucket.General);
                    pictures += $"{temp},";
                }
                pictures = pictures.Substring(0, pictures.Length - 1);
                var workshopAdd = workshop.ToWorkshopAddModel(pictures);

                var id = await _workshopService.Manager.CreateWorkshop(workshopAdd);
                return Ok(id);
            } catch (Exception ex)
            {
                foreach (var picture in pictures.Split(","))
                {
                    await _firebaseService.DeleteFile(picture, _bucket.General);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }
        [HttpGet]
        [EnableQuery]
        [Route("detail-template")]
        public async Task<IActionResult> GetWorkshopDetailTemplate([FromQuery] int workshopId)
        {
            try
            {
                var result = await _workshopService.Manager.GetDetailTemplatesByWorkshopId(workshopId);
                return Ok(result);
            }
            catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        
        [HttpGet]
        [EnableQuery]
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
            catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        //[HttpPut]
        //[Route("modify-status")]
        //public async Task<IActionResult> ModifyWorkshopStatus([FromBody] WorkshopStatusModifyModel workshop)
        //{
        //    try
        //    {
        //        await _workshopService.Manager.ModifyWorkshopStatus(workshop);
        //        return Ok();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //}
        [HttpPut]
        [Route("activate")]
        public async Task<IActionResult> ActivateWorkshop([FromQuery] int workshopId)
        {
            try
            {
                var workshop = new WorkshopStatusModifyModel
                {
                    Id = workshopId,
                    Status = (int)Models.Enum.Workshop.Status.Active,
                };
                await _workshopService.Manager.ModifyWorkshopStatus(workshop);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("deactivate")]
        public async Task<IActionResult> DeactivateWorkshop([FromQuery] int workshopId)
        {
            try
            {
                var workshop = new WorkshopStatusModifyModel
                {
                    Id = workshopId,
                    Status = (int)Models.Enum.Workshop.Status.Inactive,
                };
                await _workshopService.Manager.ModifyWorkshopStatus(workshop);
                return Ok();
            }
            catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
       
    }
}
