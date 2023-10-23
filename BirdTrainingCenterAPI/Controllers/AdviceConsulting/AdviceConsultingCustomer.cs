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
        public AdviceConsultingCustomer(IAdviceConsultingService adviceConsultingService, IAuthService authService) : base(adviceConsultingService, authService) 
        {
        }

        [HttpGet]
        [Route("customer-listConsultingTicket")]
        public async Task<IActionResult> GetListConsultingTicketByCustomerId()
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

        [HttpPost]
        [Route("sendConsultingTicket")]
        public async Task<IActionResult> SendConsultingTicket([FromBody] ConsultingTicketCreateNewModel ticket)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

            ticket.CustomerId = Int32.Parse(customerId.Value);

            await _consultingService.Customer.SendConsultingTicket(ticket);
            return Ok();
        }
    }
}
