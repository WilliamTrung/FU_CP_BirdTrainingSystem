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
using Microsoft.AspNetCore.OData.Query;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [CustomAuthorize("Staff,Manager")]
    [ApiController]
    public class AdviceConsultingStaff : AdviceConsultingBaseController, IAdviceConsultingStaff
    {
        public AdviceConsultingStaff(IAdviceConsultingService adviceConsultingService, IAuthService authService) : base(adviceConsultingService, authService)
        {
        }
        [HttpPut]
        [Route("approveConsultingTicket")]
        public async Task<IActionResult> ApproveConsultingTicket(int ticketId, int distance)
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
                
                await _consultingService.Staff.ApproveConsultingTicket(ticketId, distance);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("assignTrainer")]
        public async Task<IActionResult> AssignTrainer(int trainerId, int ticketId, int distance)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                await _consultingService.Staff.AssignTrainer(trainerId, ticketId, distance);
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
        [Route("createConsultingType")]
        public async Task<IActionResult> CreateConsultingType(ConsultingTypeCreateNewServiceModel consultingType)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            await _consultingService.Staff.CreateConsultingType(consultingType);
            return Ok();
        }

        [HttpPost]
        [Route("createNewConsultantPricePolicy")]
        public async Task<IActionResult> CreateNewConsultantPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
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
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
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
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            await _consultingService.Staff.DeleteConsultingPricePolicy(policyId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteConsultingType")]
        public async Task<IActionResult> DeleteConsultingType(int consultingTypeId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            await _consultingService.Staff.DeleteConsultingType(consultingTypeId);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteDistancePricePolicy")]
        public async Task<IActionResult> DeleteDistancePricePolicy(int distancePricePolicyId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            await  _consultingService.Staff.DeleteDistancePricePolicy(distancePricePolicyId);
            return Ok();
        }

        [HttpGet]
        [Route("get-ticket-ratio-onl-off-by-year")]
        public async Task<IActionResult> GetTicketRatioOnlOff(int? year)
        {
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _consultingService.Staff.GetTicketRatioOnlOff((int)year);
            return Ok(result);
        }

        [HttpGet ]
        [Route("get-ticket-ratio-onl-off-by-month")]
        public async Task<IActionResult> GetTicketRatioOnlOffByMonth(int? month)
        {
            if (month == null)
            {
                month = DateTime.UtcNow.AddHours(7).Month;
            }
            var result = await _consultingService.Staff.GetTicketRatioOnlOffByMonth((int)month);
            return Ok(result);
        }

        [HttpGet]
        [Route("preCalculateConsultantPrice")]
        public async Task<IActionResult> PreCalculateConsultantPrice(int ticketId, int distance)
        {
            var price = await _consultingService.Staff.PreCalculateConsultantPrice(ticketId, distance);
            return Ok(price);
        }

        [HttpPut]
        [Route("updateConsultantPricePolicy")]
        public async Task<IActionResult> UpdateConsultantPricePolicy(ConsultingPricePolicyUpdateServiceModel pricePolicy)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            if (pricePolicy.Price == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please insert the price");
            }
            await _consultingService.Staff.UpdateConsultantPricePolicy(pricePolicy);
            return Ok();
        }

        [HttpPut]
        [Route("updateConsultingType")]
        public async Task<IActionResult> UpdateConsultingType(ConsultingTypeServiceModel consultingType)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            await _consultingService.Staff.UpdateConsultingType(consultingType);
            return Ok();
        }

        [HttpPut]
        [Route("updateDistancePricePolicy")]
        public async Task<IActionResult> UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            if (distancePricePolicy.PricePerKm == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please insert the price");
            }

            await _consultingService.Staff.UpdateDistancePricePolicy(distancePricePolicy);
            return Ok();
        }

        [HttpGet]
        [Route("viewListAssignedConsultingTicket")]
        [EnableQuery]
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
        [EnableQuery]
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
        [EnableQuery]
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
