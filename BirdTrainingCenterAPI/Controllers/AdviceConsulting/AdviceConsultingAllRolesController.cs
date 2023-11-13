using AppService;
using AppService.AdviceConsultingService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Enum.Trainer;
using SP_Extension;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingAllRolesController : AdviceConsultingBaseController, IAdviceConsultingAllRoles
    {
        private readonly ITimetableService _timetableService;
        public AdviceConsultingAllRolesController(IAdviceConsultingService adviceConsultingService, IAuthService authService, ITimetableService timetableService) : base(adviceConsultingService, authService)
        {
            _timetableService = timetableService;
        }
        [HttpGet]
        [Route("GetConsultingTicketPricePolicy")]
        public async Task<IActionResult> GetConsultingTicketPricePolicy()
        {
            try
            {
                var result = await _consultingService.Other.GetConsultingPricePolicy();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetConsultingType")]
        public async Task<IActionResult> GetConsultingType()
        {
            try
            {
                var result = await _consultingService.Other.GetConsultingType();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDistnacePricePolicy")]
        public async Task<IActionResult> GetDistancePricePolicy()
        {
            try
            {
                var result = await _consultingService.Other.GetDistancePrice();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetListTrainer")]
        public async Task<IActionResult> GetListTrainer()
        {
            try
            {
                int category = (int)Models.Enum.Trainer.Category.Consulting;
                var result = await _timetableService.All.GetListTrainer(category);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTrainerFreeSlotOnDate")]
        public async Task<IActionResult> GetTrainerFreeSlotOnDate(DateTime date, int trainerId)
        {
            try
            {
                var result = await _timetableService.All.GetFreeSlotOnSelectedDateOfTrainer(date, trainerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }

        [HttpGet]
        [Route("getFreeTrainerOnSlotDate")]
        public async Task<IActionResult> GetListFreeTrainerOnSlotAndDate(DateTime date, int slotId)
        {
            try
            {
                int category = (int)Models.Enum.Trainer.Category.Consulting;
                var result = await _timetableService.All.GetListFreeTrainerOnSlotAndDate(date.ToDateOnly(), slotId, category);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Khong co trainer ranh");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getConsultingTicketDetail")]
        public async Task<IActionResult> GetConsultingTicketDetail(int ticketId)
        {
            try
            {
                var result = await _consultingService.Other.GetConsultingTicketById(ticketId);
                if (result == null)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Khong co thong tin ve ticketId nay");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
