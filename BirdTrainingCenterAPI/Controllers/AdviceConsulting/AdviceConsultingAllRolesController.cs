using AppService;
using AppService.AdviceConsultingService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingAllRolesController : AdviceConsultingBaseController, IAdviceConsultingAllRoles
    {
        public AdviceConsultingAllRolesController(IAdviceConsultingService adviceConsultingService, IAuthService authService) : base(adviceConsultingService, authService)
        {
        }
        [HttpGet]
        [Route("GetConsultingTicketPricePolicy")]
        public async Task<IActionResult> GetConsultingTicketPricePolicy()
        {
            try
            {
                var result = await _consultingService.Other.GetConsultingPricePolicy();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetConsultingType")]
        public async Task<IActionResult> GetConsultingType()
        {
            try
            {
                var result = await _consultingService.Other.GetConsultingType();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("GetDistnacePricePolicy")]
        public async Task<IActionResult> GetDistancePricePolicy()
        {
            try
            {
                var result = await _consultingService.Other.GetConsultingPricePolicy();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
