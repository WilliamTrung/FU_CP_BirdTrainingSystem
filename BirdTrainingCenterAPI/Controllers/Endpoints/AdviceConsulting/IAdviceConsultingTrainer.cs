using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.AdviceConsulting;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingTrainer
    {
        [HttpGet]
        [Route("getListAssignedConsultingTicket")]
        Task<IActionResult> GetListAssignedConsultingTicket();

        [HttpPut]
        [Route("updateGooglemeetLink")]
        Task<IActionResult> UpdateGooglemeetLink([FromQuery] int ticketId, string ggmeetLink);

        [HttpPut]
        [Route("finishAppointment")]
        Task<IActionResult> FinishAppointment([FromForm] ConsultingTicketTrainerUpdateParamModel consultingTicket);


        [HttpPut]
        [Route("finishOnlineAppointment")]
        Task<IActionResult> FinishOnlineAppointment(ConsultingTicketTrainerFinishModel consultingTicket);
    }
}
