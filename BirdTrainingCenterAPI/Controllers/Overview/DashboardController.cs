﻿using AppService.DashboardService;
using BirdTrainingCenterAPI.Controllers.Endpoints.DashboardInformative;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Models.DashboardModels;
using Models.Enum;

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
        public async Task<IActionResult> GetTrainingCourseOverview()
        {
            var result = await _dashboard.GetDashboardTrainingCourse();
            return Ok(result);
        }
        [HttpGet]
        [Route("transactions")]
        [EnableQuery]
        public async Task<IActionResult> GetTransactions(EntityType? type = null)
        {
            var result = await _dashboard.GetTransactions(type);
            return Ok(result);
        }
        [Route("campaign-revenue")]
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetCampaignRevenue([FromQuery] CampaignQueryModel query)
        {
            var result = await _dashboard.GetCampaignModel(query);
            return Ok(result);
        }
        [Route("revenue-in-year")]
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetRevenueInYear([FromQuery] int? year)
        {
            if (year == null)
                year = DateTime.UtcNow.AddHours(7).Year;
            var result = await _dashboard.GetIncomeLineChartModel((int)year);
            return Ok(result);
        }
        [Route("trainer-top")]
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetTopTrainers([FromQuery] int? month, int? year)
        {

            if(month == null)
            {
                month = DateTime.UtcNow.AddHours(7).Month;
            }
            if(year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.GetTrainerContributionModels((int)month, (int)year);
            return Ok(result);
        }
        [Route("pie-services-data")]
        [HttpGet]
        [EnableQuery]
        public async Task<IActionResult> GetPieServicesData([FromQuery] int? year)
        {
            if (year == null)
            {
                year = DateTime.UtcNow.AddHours(7).Year;
            }
            var result = await _dashboard.GetRatioTotalServices((int)year);
            return Ok(result);
        }
    }
}
