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

        [HttpPost]
        [Route("createNewAddress")]
        public async Task<IActionResult> CreateNewAddress(AddressCreateNewParamModel paramAddress)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var customerId = Int32.Parse(accessToken.First(c => c.Type == CustomClaimTypes.Id).Value);
                var address = paramAddress.Convert_ParamModel_ServiceModel(customerId);

                var result = await _consultingService.Customer.CreateNewAddress(address);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getListAddress")]
        public async Task<IActionResult> GetListAddress()
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var customerId = Int32.Parse(accessToken.First(c => c.Type == CustomClaimTypes.Id).Value);

                var result = await _consultingService.Customer.GetListAddress(customerId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
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
                var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

                //Validate kiểm tra lịch rảnh của trainer
                var trainerFreeSLot = await _timetable.All.GetFreeSlotOnSelectedDateOfTrainer(paramTicket.AppointmentDate, paramTicket.TrainerId);
                if (trainerFreeSLot == null || !trainerFreeSLot.Any())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer does not have free time at this slot of this date");
                }
                if (!trainerFreeSLot.Any(x => x.Id == paramTicket.ActualSlotStart))
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer does not have free time at this slot of this date");
                }

                //Validate Address
                if (paramTicket.OnlineOrOffline == false)
                {
                    if (string.IsNullOrWhiteSpace(paramTicket.Address))
                    {
                        return StatusCode(StatusCodes.Status503ServiceUnavailable, "Address must be fill if consulting at home");
                    }
                }
                else if (paramTicket.OnlineOrOffline == true && string.IsNullOrWhiteSpace(paramTicket.Address))
                {
                    paramTicket.Address = "online";
                }

                var ticket = paramTicket.Convert_ParamModel_ServiceModel(Int32.Parse(customerId.Value));
                //For Debug
                //ticket = paramTicket.Convert_ParamModel_ServiceModel(1);

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
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var validate = await _consultingService.Customer.ValidateBeforeUsingSendConsultingTicket(customerId);
                if (validate == false)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Customer can not using this function because being fined");
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
