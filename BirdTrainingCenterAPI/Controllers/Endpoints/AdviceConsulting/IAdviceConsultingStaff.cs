using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingStaff
    {
        [HttpGet]
        [Route("viewListHandledConsultingTicket")]
        Task<IActionResult> viewListHandledConsultingTicket();

        [HttpPut]
        [Route("assignTrainer")]
        Task<IActionResult> AssignTrainer(int trainerId, int ticketId);

        [HttpPut]
        [Route("approveConsultingTicket")]
        Task<IActionResult> ApproveConsultingTicket(int ticketId);

        [HttpPut]
        [Route("cancelConsultingTicket")]
        Task<IActionResult> CancelConsultingTicket(int ticketId);

        [HttpGet]
        [Route("viewListNotAssignedConsultingTicket")]
        Task<IActionResult> ViewListNotAssignedConsultingTicket();

        [HttpGet]
        [Route("viewListAssignedConsultingTicket")]
        Task<IActionResult> ViewListAssignedConsultingTicket();

        [HttpPost]
        [Route("createNewConsultantPricePolicy")]
        Task<IActionResult> CreateNewConsultantPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy);

        [HttpPut]
        [Route("updateConsultantPricePolicy")]
        Task<IActionResult> UpdateConsultantPricePolicy(ConsultingPricePolicyServiceModel pricePolicy);

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
    }
}
