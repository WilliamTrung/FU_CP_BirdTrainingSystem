using AppService.AdviceConsultingService;
using AppService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using TimetableSubsystem;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingStaff : AdviceConsultingBaseController, IAdviceConsultingStaff
    {
        private readonly ITimetableFeature _timetable;
        public AdviceConsultingStaff(IAdviceConsultingService adviceConsultingService, IAuthService authService, ITimetableFeature timetable) : base(adviceConsultingService, authService)
        {
            _timetable = timetable;
        }
        [HttpPut]
        [Route("approveConsultingTicket")]
        public async Task<IActionResult> ApproveConsultingTicket(int ticketId, int trainerId, DateOnly date, int slotId)
        {
            try
            {
                //Validate kiểm tra lịch rảnh của trainer
                var trainerFreeSLot = await _timetable.GetTrainerFreeSlotOnDate(date, trainerId);
                if (trainerFreeSLot == null || !trainerFreeSLot.Any())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer không có lịch rảnh vào slot này của ngày này");
                }
                if (!trainerFreeSLot.Any(x => x.Id == slotId))
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer không có lịch rảnh vào slot này của ngày này");
                }
                
                await _consultingService.Staff.ApproveConsultingTicket(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("assignTrainer")]
        public async Task<IActionResult> AssignTrainer(int trainerId, int ticketId)
        {
            try
            {
                await _consultingService.Staff.AssignTrainer(trainerId, ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("cancelConsultingTicket")]
        public async Task<IActionResult> CancelConsultingTicket(int ticketId)
        {
            try
            {
                await _consultingService.Staff.CancelConsultingTicket(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("viewListConsultingTicketByStatus")]
        public async Task<IActionResult> ViewListConsultingTicketByStatus(int status)
        {
            try
            {
                var result = await _consultingService.Staff.GetListConsultingTicketsByStatus(status);
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
