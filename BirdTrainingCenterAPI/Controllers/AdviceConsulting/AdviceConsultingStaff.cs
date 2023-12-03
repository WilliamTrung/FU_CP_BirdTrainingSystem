using AppService.AdviceConsultingService;
using AppService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using TimetableSubsystem;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Helper;
using Models.ServiceModels.AdviceConsultantModels;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingStaff : AdviceConsultingBaseController, IAdviceConsultingStaff
    {
        private readonly ITimetableService _timetable;
        public AdviceConsultingStaff(IAdviceConsultingService adviceConsultingService, IAuthService authService, ITimetableService timetable) : base(adviceConsultingService, authService)
        {
            _timetable = timetable;
        }
        [HttpPut]
        [Route("approveConsultingTicket")]
        public async Task<IActionResult> ApproveConsultingTicket(int ticketId)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }

                var trainerId = await _consultingService.Other.GetTrainerIdByTicketId(ticketId);
                var ticket = await _consultingService.Other.GetConsultingTicketByIDForDoingFunction(ticketId);
                var date = (DateTime)ticket.AppointmentDate;
                var slotId = ticket.ActualSlotStart;
                
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
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
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
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                await _consultingService.Staff.CancelConsultingTicket(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("createNewConsultantPricePolicy")]
        public async Task<IActionResult> CreateNewConsultantPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy)
        {
            var listPrice = await _consultingService.Other.GetConsultingPricePolicy();
            foreach (var price in listPrice)
            {
                if (pricePolicy.OnlineOrOffline == price.OnlineOrOffline && pricePolicy.Price == price.Price)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "This Price Policy Is Already Existed!");
                }
            }
            await _consultingService.Staff.CreateNewPricePolicy(pricePolicy);
            return Ok();
        }

        [HttpPost]
        [Route("createNewDistancePricePolicy")]
        public async Task<IActionResult> CreateNewDistancePricePolicy(DistancePricePolicyCreateNewServiceModel distancePricePolicy)
        {
            var listDistancePrice = await _consultingService.Other.GetDistancePrice();
            foreach(var distancePrice in listDistancePrice)
            {
                if (distancePricePolicy.From == distancePrice.From && 
                    distancePrice.To == distancePrice.To &&
                    distancePrice.PricePerKm == distancePrice.PricePerKm)
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "This Distance Price Policy Is Already Existed!");
                }
            } 
            await _consultingService.Staff.CreateNewDistancePricePolicy(distancePricePolicy);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteConsultantPricePolicy")]
        public async Task<IActionResult> DeleteConsultingPricePolicy(int policyId)
        {
            await _consultingService.Staff.DeleteConsultingPricePolicy(policyId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDistancePricePolicy")]
        public async Task<IActionResult> DeleteDistancePricePolicy(int distancePricePolicyId)
        {
            await  _consultingService.Staff.DeleteDistancePricePolicy(distancePricePolicyId);
            return Ok();
        }

        [HttpPut]
        [Route("updateConsultantPricePolicy")]
        public async Task<IActionResult> UpdateConsultantPricePolicy(ConsultingPricePolicyServiceModel pricePolicy)
        {
            if (pricePolicy.OnlineOrOffline == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please choose Online Or Offline");
            }
            else if (pricePolicy.Price == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please insert the price");
            }
            await _consultingService.Staff.UpdateConsultantPricePolicy(pricePolicy);
            return Ok();
        }

        [HttpPut]
        [Route("updateDistancePricePolicy")]
        public async Task<IActionResult> UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy)
        {
            if (distancePricePolicy.PricePerKm == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please insert the price");
            }

            await _consultingService.Staff.UpdateDistancePricePolicy(distancePricePolicy);
            return Ok();
        }

        [HttpGet]
        [Route("viewListAssignedConsultingTicket")]
        public async Task<IActionResult> ViewListAssignedConsultingTicket()
        {
            try
            {
                var result = await _consultingService.Staff.GetListAssignedConsultingTicket();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("viewListHandledConsultingTicket")]
        public async Task<IActionResult> viewListHandledConsultingTicket()
        {
            try
            {
                var result = await _consultingService.Staff.GetListHandledConsultingTicket();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("viewListNotAssignedConsultingTicket")]
        public async Task<IActionResult> ViewListNotAssignedConsultingTicket()
        {
            try
            {
                var result = await _consultingService.Staff.GetListNotAssignedConsultingTicket();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
