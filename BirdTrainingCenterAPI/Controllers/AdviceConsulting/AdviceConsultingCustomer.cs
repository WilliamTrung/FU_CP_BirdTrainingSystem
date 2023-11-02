using AppService;
using AppService.AdviceConsultingService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingCustomer : AdviceConsultingBaseController, IAdviceConsultingCustomer
    {
        private readonly IGoogleMapService _googleMapService;
        public AdviceConsultingCustomer(IAdviceConsultingService adviceConsultingService, IAuthService authService, IGoogleMapService googleMapService) : base(adviceConsultingService, authService) 
        {
            _googleMapService = googleMapService;
        }

        [HttpGet]
        [Route("customer-listConsultingTicket")]
        public async Task<IActionResult> GetListConsultingTicketByCustomerId()
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

                var result = await _consultingService.Customer.GetListConsultingTicketByCustomerID(Int32.Parse(customerId.Value));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("customer-sendConsultingTicket")]
        public async Task<IActionResult> SendConsultingTicket([FromBody] ConsultingTicketCreateNewModel ticket)
        {
            try
            {
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
    }
}
