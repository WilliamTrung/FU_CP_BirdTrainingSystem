using AppService;
using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Models.ApiParamModels.Workshop;
using Models.AuthModels;
using Models.ServiceModels.WorkshopModels.Feedback;
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
        [EnableQuery]
        [Route("registered-class")]
        public async Task<IActionResult> GetRegisteredClass([FromQuery]int? workshopId)
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
            if(workshopId == null)
            {
                var result = await _workshopService.Customer.GetRegisteredClass(Int32.Parse(customerId.Value));
                return Ok(result);
            } else
            {
                var result = await _workshopService.Customer.GetRegisteredClass(Int32.Parse(customerId.Value), (int)workshopId);
                return Ok(result);
            }            
        }
        //[HttpPost]89--
        //[Route("register")]
        //public async Task<IActionResult> Register([FromQuery] int workshopClassId)
        //{
        //    //var accessToken = DeserializeToken();
        //    //if (accessToken == null)
        //    //{
        //    //    return Unauthorized();
        //    //}
        //    var accessToken = Request.DeserializeToken(_authService);
        //    if (accessToken == null)
        //    {
        //        return Unauthorized();
        //    }
        //    var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
        //    try
        //    {
        //        await _workshopService.Customer.Register(Int32.Parse(customerId.Value), workshopClassId);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }
        //    return Ok();
        //}
        [HttpGet]
        [EnableQuery]
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
        [HttpGet]
        [Route("billing-information")]
        public async Task<IActionResult> GetBillingInformation(int workshopClassId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _workshopService.Customer.GetBillingInformation(Int32.Parse(customerId.Value), workshopClassId);
            return Ok(result);
        }
        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> Purchase(WorkshopPaymentModel paymentModel)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _workshopService.Customer.PurchaseClass(Int32.Parse(customerId.Value), paymentModel.WorkshopClassId, paymentModel.PaymentCode);
            return Ok();
        }
        [HttpPost]
        [Route("feedback")]
        public async Task<IActionResult> DoFeedback([FromBody] FeedbackWorkshopCustomerAddModel model)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            await _workshopService.Customer.DoFeedback(Int32.Parse(customerId.Value), model);
            return Ok();
        }
        [HttpGet]
        [Route("get-feedback")]
        public async Task<IActionResult> GetFeedback([FromQuery] int workshopId)
        {
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }
            var customerId = accessToken.First(c => c.Type == CustomClaimTypes.Id);
            var result = await _workshopService.Customer.GetFeedback(Int32.Parse(customerId.Value), workshopId);
            return Ok(result);
        }
    }
}
