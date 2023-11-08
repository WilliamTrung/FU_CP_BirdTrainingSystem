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
            try
            {
                await _workshopService.Staff.CreateWorkshopClass(workshopClass);
            } catch (InvalidDataException ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
            return Ok();
        }
        [HttpGet]
        [EnableQuery]
        [Route("get-classes")]
        public async Task<IActionResult> GetClassesByWorkshop([FromQuery] int workshopId)
        {
            try
            {
                var result = await _workshopService.Staff.GetWorkshopClassAdminViewModels(workshopId);
                foreach (var model in result)
                {
                    model.RegistrationAmount = await _workshopService.All.GetRegistrationAmount(model.Id);
                }
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("get-class-details")]
        [EnableQuery]
        public async Task<IActionResult> GetDetailsByClass([FromQuery] int workshopClassId)
        {
            try
            {
                var result = await _workshopService.Staff.GetWorkshopClassDetailByWorkshopClassId(workshopClassId);
                return Ok(result);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("modify-trainer")]
        public async Task<IActionResult> ModifyTrainerForDetail([FromBody] WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail)
        {
            try
            {
                await _workshopService.Staff.ModifyWorkshopClassDetailTrainerSlot(workshopClassDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("modify-slot")]
        public async Task<IActionResult> ModifyTrainerForDetailSlot([FromBody] WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClassDetail)
        {
            try
            {
                await _workshopService.Staff.ModifyWorkshopClassDetailSlotOnly(workshopClassDetail);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("cancel")]
        public async Task<IActionResult> CancelWorkshopClass([FromQuery] int workshopClassId)
        {
            try
            {
                await _workshopService.Staff.CancelWorkshopClass(workshopClassId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("complete")]
        public async Task<IActionResult> CompleteWorkshopClass([FromQuery] int workshopClassId)
        {
            try
            {
                await _workshopService.Staff.CompleteWorkshopClass(workshopClassId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [EnableQuery]
        [Route("workshops")]
        public async Task<IActionResult> GetWorkshops()
        {
            var result = await _workshopService.Manager.GetAllWorkshops();
            return Ok(result);
        }
    }
}
