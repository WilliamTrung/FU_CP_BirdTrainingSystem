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
using Microsoft.AspNetCore.OData.Query;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [CustomAuthorize("Staff,Manager,Trainer")]
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
        public async Task<IActionResult> FinishAppointment(int ticketId)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                
                await _consultingService.Trainer.FinishAppointment(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("updateEvidence")]
        public async Task<IActionResult> UpdateEvidence([FromForm] ConsultingTicketTrainerUpdateParamModel ticket)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var evidence = string.Empty;
            if (ticket.Evidence == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please update evidence");
            }
            foreach (var file in ticket.Evidence)
            {
                string fileName = $"{nameof(FinishAppointment)}-{ticket.Id}-{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
                var temp = await _firebaseService.UploadFile(file, fileName, FirebaseFolder.CONSULTINGTICKET, _bucket.General);
                evidence += $"{temp},";
            }
            evidence = evidence.Substring(0, evidence.Length - 1);

            var updateTicket = ticket.ToConsultingTicketUpdateModel(evidence);
            await _consultingService.Trainer.UpdateEvidence(updateTicket);
            return Ok();
        }

        [HttpPut]
        [Route("updateRecord")]
        public async Task<IActionResult> UpdateRecord(ConsultingTicketTrainerFinishModel ticket)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var evidence = string.Empty;
            if (ticket.Evidence == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Please update evidence");
            }
            await _consultingService.Trainer.UpdateEvidence(ticket);
            return Ok();
        }

        [HttpGet]
        [Route("getListAssignedConsultingTicket")]
        [EnableQuery]
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
