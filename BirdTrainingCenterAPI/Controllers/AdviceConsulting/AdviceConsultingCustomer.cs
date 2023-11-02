using AppService;
using AppService.AdviceConsultingService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System.Security.Claims;
using TimetableSubsystem;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingCustomer : AdviceConsultingBaseController, IAdviceConsultingCustomer
    {
        private readonly IGoogleMapService _googleMapService;
        private readonly ITimetableFeature _timetable;
        public AdviceConsultingCustomer(IAdviceConsultingService adviceConsultingService, IAuthService authService, IGoogleMapService googleMapService, ITimetableFeature timetable) : base(adviceConsultingService, authService) 
        {
            _googleMapService = googleMapService;
            _timetable = timetable;
        }

        [HttpGet]
        [Route("listCustomerConsultingTicket")]
        public async Task<IActionResult> GetListConsultingTicketByCustomerId(int customerId)
        {
            try
            {
                var result = await _consultingService.Customer.GetListConsultingTicketByCustomerID(customerId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("sendConsultingTicket")]
        public async Task<IActionResult> SendConsultingTicket([FromBody] ConsultingTicketCreateNewModel ticket)
        {
            try
            {
                //Validate kiểm tra lịch rảnh của trainer
                var trainerFreeSLot = await _timetable.GetTrainerFreeSlotOnDate(ticket.AppointmentDate , ticket.TrainerId);
                if (trainerFreeSLot == null || !trainerFreeSLot.Any())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer không có lịch rảnh vào slot này của ngày này");
                }
                if (!trainerFreeSLot.Any(x => x.Id == ticket.ActualSlotStart))
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer không có lịch rảnh vào slot này của ngày này");
                }

                int distance = 0;
                if (ticket.Address != null)
                {
                    distance = (int)await _googleMapService.CalculateDistance(ticket.Address);
                }
                await _consultingService.Customer.SendConsultingTicket(ticket, distance);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }        
        }

        public async Task<IActionResult> ValidateBeforeUsingSendConsultingTicket(int customerId)
        {
            try
            {
                var validate = await _consultingService.Customer.ValidateBeforeUsingSendConsultingTicket(customerId);
                if (validate == false)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Người dùng không thể sử dụng chức năng này vì đang bị giới hạn");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
