using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.AdviceConsulting;
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
        Task<IActionResult> UpdateAppointment([FromQuery] int ticketId, string ggmeetLink);

        [HttpPut]
        [Route("trainer-finishAppointment")]
        Task<IActionResult> FinishAppointment([FromForm] ConsultingTicketTrainerUpdateParamModel consultingTicket);
    }
}
