using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [CustomAuthorize(roles:"Manager,Staff")]
    public class WorkshopStaffController : WorkshopBaseController, IWorkshopStaff
    {
        public WorkshopStaffController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }
        [HttpPost]
        [Route("create-class")]
        public async Task<IActionResult> CreateWorkshopClass([FromBody] WorkshopClassAddModel workshopClass)
        {
            await _workshopService.Staff.CreateWorkshopClass(workshopClass);
            return Ok();
        }
        [HttpGet]
        [EnableQuery]
        [Route("get-classes")]
        public async Task<IActionResult> GetClassesByWorkshop([FromQuery] int workshopId)
        {
            var result = await _workshopService.Staff.GetWorkshopClassAdminViewModels(workshopId);
            foreach (var model in result)
            {
                model.RegistrationAmount = await _workshopService.All.GetRegistrationAmount(model.Id);
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("staff-class-by-id")]
        public async Task<IActionResult> GetClassAdminById([FromQuery] int classId)
        {
            var result = await _workshopService.Staff.GetClassAdminViewById(classId);
            result.RegistrationAmount = await _workshopService.All.GetRegistrationAmount(classId);
            return Ok(result);
        }
        [HttpGet]
        [Route("get-class-details")]
        [EnableQuery]
        public async Task<IActionResult> GetDetailsByClass([FromQuery] int workshopClassId)
        {
            var result = await _workshopService.Staff.GetWorkshopClassDetailByWorkshopClassId(workshopClassId);
            return Ok(result);
        }
        [HttpPut]
        [Route("modify-trainer")]
        public async Task<IActionResult> ModifyTrainerForDetail([FromBody] WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail)
        {
            await _workshopService.Staff.ModifyWorkshopClassDetailTrainerSlot(workshopClassDetail);
            return Ok();
        }
        [HttpPut]
        [Route("modify-slot")]
        public async Task<IActionResult> ModifyTrainerForDetailSlot([FromBody] WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClassDetail)
        {
            await _workshopService.Staff.ModifyWorkshopClassDetailSlotOnly(workshopClassDetail);
            return Ok();
        }
        [HttpPut]
        [Route("cancel")]
        public async Task<IActionResult> CancelWorkshopClass([FromBody] int workshopClassId)
        {
            await _workshopService.Staff.CancelWorkshopClass(workshopClassId);
            return Ok();
        }
        [HttpPut]
        [Route("complete")]
        public async Task<IActionResult> CompleteWorkshopClass([FromBody] int workshopClassId)
        {
            await _workshopService.Staff.CompleteWorkshopClass(workshopClassId);
            return Ok();
        }
        [HttpPut]
        [Route("on-going")]
        public async Task<IActionResult> SetWorkshopClassOnGoing([FromBody] int workshopClassId)
        {
            await _workshopService.Staff.SetWorkshopClassOngoing(workshopClassId);
            return Ok();
        }
        [HttpPut]
        [Route("close-registration")]
        public async Task<IActionResult> CloseRegistrationWorkshopClass([FromBody] int workshopClassId)
        {
            await _workshopService.Staff.CloseRegistrationWorkshopClass(workshopClassId);
            return Ok();
        }
        [HttpGet]
        [EnableQuery]
        [Route("workshops")]
        public async Task<IActionResult> GetWorkshops()
        {
            var result = await _workshopService.Manager.GetAllWorkshops();
            return Ok(result);
        }
        [HttpPut]
        [Route("modify-class")]
        public async Task<IActionResult> ModifyWorkshopClass([FromBody] WorkshopClassModifyModel modified)
        {
            await _workshopService.Staff.ModifyWorkshopClass(modified);
            return Ok();
        }
    }
}
