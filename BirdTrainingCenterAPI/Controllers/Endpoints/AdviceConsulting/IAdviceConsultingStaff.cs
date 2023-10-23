using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingStaff
    {
        [HttpGet]
        [Route("staff-viewListConsultingTicketByStatus")]
        Task<IActionResult> ViewListConsultingTicketByStatus(int status);
        [HttpPut]
        [Route("staff-assignTrainer")]
        Task<IActionResult> AssignTrainer(ConsultingTicketUpdateModel consultingTicket);
        [HttpPut]
        [Route("staff-approveConsultingTicket")]
        Task<IActionResult> ApproveConsultingTicket(ConsultingTicketUpdateStatusModel consultingTicket);
        [HttpPut]
        [Route("staff-cancelConsultingTicket")]
        Task<IActionResult> CancelConsultingTicket(ConsultingTicketUpdateStatusModel consultingTicket);
    }
}
