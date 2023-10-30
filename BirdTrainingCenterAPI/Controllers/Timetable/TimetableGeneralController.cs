using AppService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Timetable;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

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
    }
}
