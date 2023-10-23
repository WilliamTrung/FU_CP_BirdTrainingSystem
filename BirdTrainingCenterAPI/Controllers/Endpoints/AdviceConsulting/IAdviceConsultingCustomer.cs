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
        [Route("customer-listConsultingTicket")]
        Task<IActionResult> GetListConsultingTicketByCustomerId();
    }
}
