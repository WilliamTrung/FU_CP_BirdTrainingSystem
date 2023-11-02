using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingCustomer
    {
        [HttpPost]
        [Route("sendConsultingTicket")]
        Task<IActionResult>SendConsultingTicket([FromBody] ConsultingTicketCreateNewModel ticket);

        [HttpGet]
        [Route("listCustomerConsultingTicket")]
        Task<IActionResult> GetListConsultingTicketByCustomerId(int customerId);

        [HttpGet]
        [Route("validateBeforeUsingSendConsultingTicket")]
        Task<IActionResult> ValidateBeforeUsingSendConsultingTicket(int customerId);
    }
}
