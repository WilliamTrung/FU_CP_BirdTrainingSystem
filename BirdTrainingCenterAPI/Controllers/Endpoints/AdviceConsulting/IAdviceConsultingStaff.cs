﻿using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingStaff
    {
        [HttpGet]
        [Route("viewListConsultingTicketByStatus")]
        Task<IActionResult> ViewListConsultingTicketByStatus(int status);

        [HttpPut]
        [Route("assignTrainer")]
        Task<IActionResult> AssignTrainer(int trainerId, int ticketId);

        [HttpPut]
        [Route("approveConsultingTicket")]
        Task<IActionResult> ApproveConsultingTicket(int ticketId);

        [HttpPut]
        [Route("cancelConsultingTicket")]
        Task<IActionResult> CancelConsultingTicket(int ticketId);
    }
}
