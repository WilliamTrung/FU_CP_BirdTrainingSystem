using AppService.AdviceConsultingService;
using AppService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingStaff : AdviceConsultingBaseController, IAdviceConsultingStaff
    {
        public AdviceConsultingStaff(IAdviceConsultingService adviceConsultingService, IAuthService authService) : base(adviceConsultingService, authService)
        {
        }
        [HttpPut]
        [Route("staff-approveConsultingTicket")]
        public async Task<IActionResult> ApproveConsultingTicket(ConsultingTicketUpdateStatusModel consultingTicket)
        {
            await _consultingService.Staff.ApproveConsultingTicket(consultingTicket);
            return Ok();
        }

        [HttpPut]
        [Route("staff-assignTrainer")]
        public async Task<IActionResult> AssignTrainer(ConsultingTicketUpdateModel consultingTicket)
        {
            await _consultingService.Staff.AssignTrainer(consultingTicket);
            return Ok();
        }

        [HttpPut]
        [Route("staff-cancelConsultingTicket")]
        public async Task<IActionResult> CancelConsultingTicket(ConsultingTicketUpdateStatusModel consultingTicket)
        {
            await _consultingService.Staff.CancelConsultingTicket(consultingTicket);
            return Ok();
        }

        [HttpGet]
        [Route("staff-viewListConsultingTicketByStatus")]
        public async Task<IActionResult> ViewListConsultingTicketByStatus(int status)
        {
            var result = await _consultingService.Staff.GetListConsultingTicketsByStatus(status);
            return Ok(result);
        }
    }
}
