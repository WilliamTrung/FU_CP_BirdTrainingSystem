using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingStaff
    {
        [HttpGet]
        [Route("viewListHandledConsultingTicket")]
        [EnableQuery]
        Task<IActionResult> viewListHandledConsultingTicket();

        [HttpPut]
        [Route("assignTrainer")]
        Task<IActionResult> AssignTrainer(int trainerId, int ticketId, int distance);

        [HttpPut]
        [Route("approveConsultingTicket")]
        Task<IActionResult> ApproveConsultingTicket(int ticketId, int distance);

        [HttpPut]
        [Route("cancelConsultingTicket")]
        Task<IActionResult> CancelConsultingTicket(int ticketId);

        [HttpGet]
        [Route("viewListNotAssignedConsultingTicket")]
        [EnableQuery]
        Task<IActionResult> ViewListNotAssignedConsultingTicket();

        [HttpGet]
        [Route("viewListAssignedConsultingTicket")]
        [EnableQuery]
        Task<IActionResult> ViewListAssignedConsultingTicket();

        [HttpPost]
        [Route("createNewConsultantPricePolicy")]
        Task<IActionResult> CreateNewConsultantPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy);

        [HttpPut]
        [Route("updateConsultantPricePolicy")]
        Task<IActionResult> UpdateConsultantPricePolicy(ConsultingPricePolicyUpdateServiceModel pricePolicy);

        [HttpDelete]
        [Route("deleteConsultantPricePolicy")]
        Task<IActionResult> DeleteConsultingPricePolicy(int policyId);

        [HttpPost]
        [Route("createNewDistancePricePolicy")]
        Task<IActionResult> CreateNewDistancePricePolicy(DistancePricePolicyCreateNewServiceModel distancePricePolicy);

        [HttpPut]
        [Route("updateDistancePricePolicy")]
        Task<IActionResult> UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy);

        [HttpDelete]
        [Route("deleteDistancePricePolicy")]
        Task<IActionResult> DeleteDistancePricePolicy(int distancePricePolicyId);

        [HttpGet]
        [Route("preCalculateConsultantPrice")]
        Task<IActionResult> PreCalculateConsultantPrice(int ticketId, int distance);

        [HttpPut]
        [Route("updateConsultingType")]
        Task<IActionResult> UpdateConsultingType(ConsultingTypeServiceModel consultingType);

        [HttpDelete]
        [Route("deleteConsultingType")]
        Task<IActionResult> DeleteConsultingType(int consultingTypeId);

        [HttpPost]
        [Route("createConsultingType")]
        Task<IActionResult> CreateConsultingType(ConsultingTypeCreateNewServiceModel consultingType);

        [HttpGet]
        [Route("get-ticket-ratio-onl-off-by-year")]
        Task<IActionResult> GetTicketRatioOnlOff(int? year);

        [HttpGet]
        [Route("get-ticket-ratio-onl-off-by-month")]
        Task<IActionResult> GetTicketRatioOnlOffByMonth(int? month);
    }
}
