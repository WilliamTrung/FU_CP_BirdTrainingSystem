using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.AuthModels;
using SP_Middleware;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [CustomAuthorize(roles: "Trainer")]
    public class WorkshopTrainerController : WorkshopBaseController, IWorkshopTrainer
    {
        public WorkshopTrainerController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }
        [HttpGet]
        [EnableQuery]
        [Route("assigned-classes")]
        public async Task<IActionResult> GetAssignedClasses([FromQuery] int workshopId)
        {
            //var accessToken = DeserializeToken();
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            try
            {
                var result = await _workshopService.Trainer.GetAssignedWorkshopClasses(trainerId: Int32.Parse(trainerId.Value), workshopId: workshopId);
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
        [Route("assigned-slots")]
        public async Task<IActionResult> GetAssignedSlots([FromQuery] int workshopClassId)
        {
            //var accessToken = DeserializeToken();
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            try
            {
                var result = await _workshopService.Trainer.GetAssignedWorkshopClassDetails(trainerId: Int32.Parse(trainerId.Value), workshopClassId: workshopClassId);
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
        [Route("assigned-workshops")]
        public async Task<IActionResult> GetAssignedWorkshops()
        {
            //var accessToken = DeserializeToken();
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            try
            {
                var result = await _workshopService.Trainer.GetAssignedWorkshops(trainerId: Int32.Parse(trainerId.Value));
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
    }
}
