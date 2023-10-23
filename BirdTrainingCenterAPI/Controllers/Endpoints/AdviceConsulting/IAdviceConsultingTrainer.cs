using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingTrainer
    {
        [HttpGet]
        [Route("trainer-viewAssignedAppointmet")]
        Task<IActionResult> ViewAssignedAppointment();
        [HttpPut]
        [Route("trainer-updateAppointment")]
        Task<IActionResult> UpdateAppointment(ConsultingTicketUpdateModel consultingTicket);
        [HttpPut]
        [Route("trainer-finishAppointment")]
        Task<IActionResult> FinishAppointment(ConsultingTicketUpdateStatusModel consultingTicket);
        [HttpPut]
        [Route("trainer-fillingOutBillingForm")]
        Task<IActionResult> FillOutBillingForm(ConsultingTicketBillModel consultingTicket);
    }
}
