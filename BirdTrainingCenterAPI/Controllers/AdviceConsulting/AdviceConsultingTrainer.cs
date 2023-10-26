using AppService.AdviceConsultingService;
using AppService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using BirdTrainingCenterAPI.Helper;
using System.Security.Claims;
using Models.AuthModels;
using Models.ApiParamModels.AdviceConsulting;
using Models.ConfigModels;
using Microsoft.Extensions.Options;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingTrainer : AdviceConsultingBaseController, IAdviceConsultingTrainer
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public AdviceConsultingTrainer(IAdviceConsultingService adviceConsultingService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket) : base(adviceConsultingService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
        }

        [HttpPut]
        [Route("trainer-finishAppointment")]
        public async Task<IActionResult> FinishAppointment(ConsultingTicketTrainerUpdateParamModel consultingTicket)
        {
            try
            {
                var evidence = string.Empty;
                foreach (var file in consultingTicket.Evidence)
                {
                    var temp = await _firebaseService.UploadFile(file, file.FileName, FirebaseFolder.CONSULTINGTICKET, _bucket.General);
                    evidence += $"{temp},";
                }
                evidence = evidence.Substring(0, evidence.Length - 1);
                var updateTicket = consultingTicket.ToConsultingTicketUpdateModel(evidence);

                await _consultingService.Trainer.FinishAppointment(updateTicket);
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
