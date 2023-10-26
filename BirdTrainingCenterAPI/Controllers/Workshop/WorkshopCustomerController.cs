﻿using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.AuthModels;
using SP_Middleware;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [CustomAuthorize(roles: "Customer")]
    public class WorkshopCustomerController : WorkshopBaseController, IWorkshopCustomer
    {
        public WorkshopCustomerController(IWorkshopService workshopService, IAuthService authService) : base(workshopService, authService)
        {
        }

        [HttpGet]
        [Route("registered-class")]
        public async Task<IActionResult> GetRegisteredClass([FromQuery]int workshopId)
        {
            //var accessToken = DeserializeToken();
            //if(accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

            var result = await _workshopService.Customer.GetRegisteredClass(Int32.Parse(customerId.Value), workshopId);
            return Ok(result);

        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromQuery] int workshopClassId)
        {
            //var accessToken = DeserializeToken();
            //if (accessToken == null)
            //{
            //    return Unauthorized();
            //}
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            try
            {
                await _workshopService.Customer.Register(Int32.Parse(customerId.Value), workshopClassId);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            return Ok();
        }
        [HttpGet]
        [Route("registered-workshop")]
        public async Task<IActionResult> GetRegisteredWorkshops()
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);

            var result = await _workshopService.Customer.GetRegisteredWorkshopss(Int32.Parse(customerId.Value));
            return Ok(result);
        }
    }
}
