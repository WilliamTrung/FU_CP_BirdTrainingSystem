using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using static BirdTrainingCenterAPI.Controllers.ErrorsController;

namespace BirdTrainingCenterAPI.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var code = StatusCodes.Status400BadRequest;

            if (exception is KeyNotFoundException) code = StatusCodes.Status404NotFound; // Not Found
            else if (exception is InvalidOperationException) code = StatusCodes.Status406NotAcceptable;
            else if (exception is InvalidDataException) code = StatusCodes.Status409Conflict;
            else if (exception is NotImplementedException) code = StatusCodes.Status501NotImplemented;
            else if (exception is Exception) code = StatusCodes.Status500InternalServerError; // Bad Request

            Response.StatusCode = code; // You can use HttpStatusCode enum instead

            return new ErrorResponse(exception); // Your error model
        }
        public class ErrorResponse
        {
            public string Type { get; set; }
            public string Message { get; set; }
            public string StackTrace { get; set; }

            public ErrorResponse(Exception ex)
            {
                Type = ex.GetType().Name;
                Message = ex.Message;
                StackTrace = ex.ToString();
            }
        }
    }
}
