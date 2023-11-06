using AppService;
using AppService.AdviceConsultingService;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.AdviceConsulting;
using Models.AuthModels;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using SP_Extension;
using System.Security.Claims;
using TimetableSubsystem;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingCustomer : AdviceConsultingBaseController, IAdviceConsultingCustomer
    {
        private readonly IGoogleMapService _googleMapService;
        private readonly ITimetableService _timetable;
        public AdviceConsultingCustomer(IAdviceConsultingService adviceConsultingService, IAuthService authService, IGoogleMapService googleMapService, ITimetableService timetable) : base(adviceConsultingService, authService) 
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
        public async Task<IActionResult> SendConsultingTicket([FromBody] ConsultingTicketCreateNewParamModel paramTicket)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                //var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                //var ticket = paramTicket.Convert_ParamModel_ServiceModel(Int32.Parse(customerId.Value));
                var ticket = paramTicket.Convert_ParamModel_ServiceModel(1);

                //Validate kiểm tra lịch rảnh của trainer
                var trainerFreeSLot = await _timetable.All.GetFreeSlotOnSelectedDateOfTrainer(paramTicket.AppointmentDate, paramTicket.TrainerId);
                if (trainerFreeSLot == null || !trainerFreeSLot.Any())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer không có lịch rảnh vào slot này của ngày này");
                }
                if (!trainerFreeSLot.Any(x => x.Id == paramTicket.ActualSlotStart))
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer không có lịch rảnh vào slot này của ngày này");
                }

                int distance = 0;
                //if (address != null)
                //{
                //    distance = (int)await _googlemapservice.calculatedistance(address);
                //}
                await _consultingService.Customer.SendConsultingTicket(ticket, distance);
                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }        
        }

        [HttpGet]
        [Route("validateBeforeUsingSendConsultingTicket")]
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
