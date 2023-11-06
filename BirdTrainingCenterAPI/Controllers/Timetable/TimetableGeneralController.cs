using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ApiParamModels.Timetable;

namespace BirdTrainingCenterAPI.Controllers.Timetable
{
    [ApiController]
    public class TimetableGeneralController : TimetableBaseController, ITimetableGeneral
    {
        public TimetableGeneralController(ITimetableService timetableService, IAuthService authService) : base(timetableService, authService)
        {
        }
        [HttpGet]
        [EnableQuery]
        [Route("slot-detail")]
        public async Task<IActionResult> GetOccupiedSlots([FromQuery] int trainerSlotId)
        {
            try
            {
                var result = await _timetableService.All.GetTrainerSlotDetail(trainerSlotId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("free-trainers")]
        public async Task<IActionResult> GetTrainerFreeOnSlotAndDate([FromBody]GetTrainerFreeOnSlotAndDate model, [FromQuery] string category)
        {
            try
            {
                var categoryEnum = (Models.Enum.Trainer.Category)Enum.Parse(typeof(Models.Enum.Trainer.Category), category, true);
                var result = await _timetableService.All.GetListFreeTrainerOnSlotAndDate(model.date, model.slotId, (int)categoryEnum);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
