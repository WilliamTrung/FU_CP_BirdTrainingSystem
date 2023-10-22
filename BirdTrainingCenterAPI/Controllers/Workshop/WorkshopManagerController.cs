using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.WorkshopModels;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopManagerController : WorkshopStaffController, IWorkshopManager
    {
        public WorkshopManagerController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }

        public async Task<IActionResult> CreateWorkshop([FromForm] WorkshopAddModel workshop)
        {
            try
            {
                await _workshopService.Manager.CreateWorkshop(workshop);
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }            
        }

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

        public async Task<IActionResult> GetWorkshopStatuses()
        {
            var result = await _workshopService.Manager.GetWorkshopStatuses();
            return Ok(result);
        }

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
