﻿using AppService.DashboardService;
using BirdTrainingCenterAPI.Controllers.Endpoints.DashboardInformative;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace BirdTrainingCenterAPI.Controllers.Overview
{
    [Route("api/overview")]
    [ApiController]
    public class DashboardController : ODataController, IDashboard
    {
        private readonly IDashboardService _dashboard;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboard = dashboardService;
        }
        [HttpGet]
        [Route("consulting-ticket")]
        [EnableQuery]
        public async Task<IActionResult> GetConsultingTicketOverview()
        {
            var result = await _dashboard.GetDashboardConsultingTicket();
            return Ok(result);
        }
        [HttpGet]
        [Route("online-course")]
        [EnableQuery]
        public async Task<IActionResult> GetOnlineCourseOverview()
        {
            var result = await _dashboard.GetDashboardOnlineCourse();
            return Ok(result);
        }
        [HttpGet]
        [Route("workshop")]
        [EnableQuery]
        public async Task<IActionResult> GetWorkshopOverview()
        {
            var result = await _dashboard.GetDashboardWorkshop();
            return Ok(result);
        }
        [HttpGet]
        [Route("training-course")]
        [EnableQuery]
        public Task<IActionResult> GetTrainingCourseOverview()
        {
            throw new NotImplementedException();
        }
    }
}
