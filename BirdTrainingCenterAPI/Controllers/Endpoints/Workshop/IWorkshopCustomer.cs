﻿using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Workshop;
using Models.ServiceModels.WorkshopModels.Feedback;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Workshop
{
    public interface IWorkshopCustomer
    {
        //[HttpPost]
        //[Route("register")]
        //Task<IActionResult> Register([FromQuery] int workshopClassId);

        [HttpGet]
        [Route("registered-class")]
        Task<IActionResult> GetRegisteredClass([FromQuery]int? workshopId);
        [HttpGet]
        [Route("registered-workshop")]
        Task<IActionResult> GetRegisteredWorkshops();
        [Route("billing-information")]
        Task<IActionResult> GetBillingInformation(int workshopClassId);
        [Route("purchase")]
        Task<IActionResult> Purchase(WorkshopPaymentModel paymentModel);
        [Route("feedback")]
        Task<IActionResult> DoFeedback([FromBody] FeedbackWorkshopCustomerAddModel model);
        [Route("get-feedback")]
        Task<IActionResult> GetFeedback([FromQuery] int workshopId);
    }
}
