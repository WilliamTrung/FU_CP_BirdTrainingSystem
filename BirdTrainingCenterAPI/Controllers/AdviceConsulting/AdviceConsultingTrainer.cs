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
            var result = await _consultingService.Trainer.FillOutBillingForm(consultingTicket);
            return Ok(result);
        }

        [HttpPut]
        [Route("trainer-finishAppointment")]
        public async Task<IActionResult> FinishAppointment(ConsultingTicketUpdateStatusModel consultingTicket)
        {
            await _consultingService.Trainer.FinishAppointment(consultingTicket);
            return Ok();
        }

        [HttpPut]
        [Route("trainer-updateAppointment")]
        public async Task<IActionResult> UpdateAppointment(int ticketId, string ggmeetLink)
        {
            await _consultingService.Trainer.UpdateAppointment(ticketId, ggmeetLink);
            return Ok();
        }

        [HttpGet]
        [Route("trainer-viewAssignedAppointmet")]
        public async Task<IActionResult> ViewAssignedAppointment()
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
    }
}
