using AppService.AdviceConsultingService;
using AppService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using BirdTrainingCenterAPI.Helper;
using System.Security.Claims;
using Models.AuthModels;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingTrainer : AdviceConsultingBaseController, IAdviceConsultingTrainer
    {
        public AdviceConsultingTrainer(IAdviceConsultingService adviceConsultingService, IAuthService authService) : base(adviceConsultingService, authService)
        {
        }

        [HttpPut]
        [Route("trainer-fillingOutBillingForm")]
        public async Task<IActionResult> FillOutBillingForm(ConsultingTicketBillModel consultingTicket)
        {
            try
            {

                var result = await _consultingService.Trainer.FillOutBillingForm(consultingTicket);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("trainer-finishAppointment")]
        public async Task<IActionResult> FinishAppointment(ConsultingTicketUpdateStatusModel consultingTicket)
        {
            try
            {
                await _consultingService.Trainer.FinishAppointment(consultingTicket);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("trainer-updateAppointment")]
        public async Task<IActionResult> UpdateAppointment(int ticketId, string ggmeetLink)
        {
            try
            {

                await _consultingService.Trainer.UpdateAppointment(ticketId, ggmeetLink);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("trainer-viewAssignedAppointmet")]
        public async Task<IActionResult> ViewAssignedAppointment()
        {
            try
            {

                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                var result = await _consultingService.Trainer.ViewAssignedAppointment(Int32.Parse(trainerId.Value));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
