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
    
    public class WorkshopTrainerController : WorkshopBaseController, IWorkshopTrainer
    {
        public WorkshopTrainerController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }
        [CustomAuthorize(roles: "Trainer")]
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
            var result = await _workshopService.Trainer.GetAssignedWorkshopClasses(trainerId: Int32.Parse(trainerId.Value), workshopId: workshopId);
            return Ok(result);
        }
        [HttpGet]
        [CustomAuthorize(roles: "Trainer,Manager,Staff")]
        [EnableQuery]
        [Route("get-by-entity-id")]
        public async Task<IActionResult> GetTrainerSlotByEntityId([FromQuery]int entityId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var role = accessToken.First(c => c.Type == CustomClaimTypes.Role);
            int? trainerId = null;
            if(role.Value == Enum.GetName(typeof(Models.Enum.Role), Models.Enum.Role.Trainer))
            {
                var token = accessToken.First(c => c.Type == CustomClaimTypes.Id).Value;
                trainerId = Int32.Parse(token);
            }
            
            var result = await _workshopService.Trainer.GetTrainerSlotByEntityId(trainerId, entityId);

            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [CustomAuthorize(roles: "Trainer")]
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
            var result = await _workshopService.Trainer.GetAssignedWorkshopClassDetails(trainerId: Int32.Parse(trainerId.Value), workshopClassId: workshopClassId);
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [CustomAuthorize(roles: "Trainer")]
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
            var result = await _workshopService.Trainer.GetAssignedWorkshops(trainerId: Int32.Parse(trainerId.Value));
            return Ok(result);
        }
    }
}
