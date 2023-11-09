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

        [HttpGet]
        [Route("GetListTrainer")]
        Task<IActionResult> GetListTrainer();

        [HttpGet]
        [Route("GetTrainerFreeSlotOnDate")]
        Task<IActionResult> GetTrainerFreeSlotOnDate(DateTime date, int trainerId);

        [HttpGet]
        [Route("getFreeTrainerOnSlotDate")]
        Task<IActionResult> GetListFreeTrainerOnSlotAndDate(DateTime date, int slotId);
    }
}
