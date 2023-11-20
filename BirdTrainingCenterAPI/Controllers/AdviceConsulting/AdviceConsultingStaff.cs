﻿using AppService.AdviceConsultingService;
using AppService;
using BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using TimetableSubsystem;
using AppService.TimetableService;
using BirdTrainingCenterAPI.Helper;

namespace BirdTrainingCenterAPI.Controllers.AdviceConsulting
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdviceConsultingStaff : AdviceConsultingBaseController, IAdviceConsultingStaff
    {
        private readonly ITimetableService _timetable;
        public AdviceConsultingStaff(IAdviceConsultingService adviceConsultingService, IAuthService authService, ITimetableService timetable) : base(adviceConsultingService, authService)
        {
            _timetable = timetable;
        }
        [HttpPut]
        [Route("approveConsultingTicket")]
        public async Task<IActionResult> ApproveConsultingTicket(int ticketId)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }

                var trainerId = await _consultingService.Other.GetTrainerIdByTicketId(ticketId);
                var ticket = await _consultingService.Other.GetConsultingTicketByIDForDoingFunction(ticketId);
                var date = (DateTime)ticket.AppointmentDate;
                var slotId = ticket.ActualSlotStart;

                //Validate kiểm tra lịch rảnh của trainer
                var trainerFreeSLot = await _timetable.All.GetFreeSlotOnSelectedDateOfTrainer(date, trainerId);
                if (trainerFreeSLot == null || !trainerFreeSLot.Any())
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer does not have free time at this slot of this date");
                }
                if (!trainerFreeSLot.Any(x => x.Id == slotId))
                {
                    return StatusCode(StatusCodes.Status503ServiceUnavailable, "Trainer does not have free time at this slot of this date");
                }
                
                await _consultingService.Staff.ApproveConsultingTicket(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("assignTrainer")]
        public async Task<IActionResult> AssignTrainer(int trainerId, int ticketId)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                await _consultingService.Staff.AssignTrainer(trainerId, ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("cancelConsultingTicket")]
        public async Task<IActionResult> CancelConsultingTicket(int ticketId)
        {
            try
            {
                var accessToken = Request.DeserializeToken(_authService);
                if (accessToken == null)
                {
                    return Unauthorized();
                }
                await _consultingService.Staff.CancelConsultingTicket(ticketId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("viewListAssignedConsultingTicket")]
        public async Task<IActionResult> ViewListAssignedConsultingTicket()
        {
            try
            {
                var result = await _consultingService.Staff.GetListAssignedConsultingTicket();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("viewListHandledConsultingTicket")]
        public async Task<IActionResult> viewListHandledConsultingTicket()
        {
            try
            {
                var result = await _consultingService.Staff.GetListHandledConsultingTicket();
                return Ok(result);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("viewListNotAssignedConsultingTicket")]
        public async Task<IActionResult> ViewListNotAssignedConsultingTicket()
        {
            try
            {
                var result = await _consultingService.Staff.GetListNotAssignedConsultingTicket();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
