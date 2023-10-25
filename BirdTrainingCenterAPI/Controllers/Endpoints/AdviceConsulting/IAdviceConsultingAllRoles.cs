using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingAllRoles
    {
        [HttpGet]
        [Route("GetConsultingTicketPricePolicy")]
        Task<IActionResult> GetConsultingTicketPricePolicy();

        [HttpGet]
        [Route("GetDistnacePricePolicy")]
        Task<IActionResult> GetDistancePricePolicy();

        [HttpGet]
        [Route("GetConsultingType")]
        Task<IActionResult> GetConsultingType();
    }
}
