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
using AppService.TimetableService;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingTrainer : AdviceConsultingBaseController, IAdviceConsultingTrainer
    {
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        private readonly ITimetableService _timetableService;
        public AdviceConsultingTrainer(IAdviceConsultingService adviceConsultingService, IAuthService authService, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket, ITimetableService timetableService) : base(adviceConsultingService, authService)
        {
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
            _timetableService = timetableService;
        }

        [HttpPut]
        [Route("finishAppointment")]
        public async Task<IActionResult> FinishAppointment([FromForm]ConsultingTicketTrainerUpdateParamModel consultingTicket)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var evidence = string.Empty;
                if (consultingTicket.Evidence  == null)
                {
                    return BadRequest("Please update evidince");
                }
                foreach (var file in consultingTicket.Evidence)
                {
                    string fileName = $"{nameof(FinishAppointment)}-{consultingTicket.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                    var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.CONSULTINGTICKET, _bucket.General);
                    evidence += $"{temp},";
                }
                evidence = evidence.Substring(0, evidence.Length - 1);
                var ticket = consultingTicket.ToConsultingTicketUpdateModel(evidence);

                await _consultingService.Trainer.FinishAppointment(ticket);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("finishOnlineAppointment")]
        public async Task<IActionResult> FinishOnlineAppointment(ConsultingTicketTrainerFinishModel consultingTicket)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            if (consultingTicket.Evidence == null)
            {
                return BadRequest("Please update evidence");
            }
            await _consultingService.Trainer.FinishAppointment(consultingTicket);
            return Ok();
        }

        [HttpPut]
        [Route("updateGooglemeetLink")]
        public async Task<IActionResult> UpdateGooglemeetLink(int ticketId, string ggmeetLink)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                await _consultingService.Trainer.UpdateAppointment(ticketId, ggmeetLink);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getListAssignedConsultingTicket")]
        public async Task<IActionResult> GetListAssignedConsultingTicket()
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                var trainerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
                var result = await _consultingService.Trainer.GetListAssignedConsultingTicket(Int32.Parse(trainerId.Value));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("getAvailableFinishTime")]
        public async Task<IActionResult> GetAvailableFinishTime(string actualStartSlot)
        {
            var result = await _timetableService.Trainer.GetAvailableFinishTime(actualStartSlot);
            return Ok(result);
        }
    }
}
