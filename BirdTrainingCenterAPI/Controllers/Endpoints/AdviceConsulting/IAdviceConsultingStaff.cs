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
        Task<IActionResult> AssignTrainer(int trainerId, int ticketId);
        [HttpPut]
        [Route("staff-approveConsultingTicket")]
        Task<IActionResult> ApproveConsultingTicket(int ticketId);
        [HttpPut]
        [Route("staff-cancelConsultingTicket")]
        Task<IActionResult> CancelConsultingTicket(int ticketId);
    }
}
