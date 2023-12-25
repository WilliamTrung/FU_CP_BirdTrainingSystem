using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ApiParamModels.AdviceConsulting;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingTrainer
    {
        [HttpGet]
        [Route("getListAssignedConsultingTicket")]
        [EnableQuery]
        Task<IActionResult> GetListAssignedConsultingTicket();

        [HttpPut]
        [Route("finishAppointment")]
        Task<IActionResult> FinishAppointment(int ticketId);

        [HttpPut]
        [Route("updateEvidence")]
        Task<IActionResult> UpdateEvidence([FromForm] ConsultingTicketTrainerUpdateParamModel ticket);

        [HttpPut]
        [Route("updateRecord")]
        Task<IActionResult> UpdateRecord(ConsultingTicketTrainerFinishModel ticket);

        [HttpGet]
        [Route("getAvailableFinishTime")]
        Task<IActionResult> GetAvailableFinishTime(string actualSlotStart);
    }
}
