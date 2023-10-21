using AppService.WorkshopService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [Route("api/workshop")]
    [ApiController]
    public class WorkshopBaseController : ControllerBase
    {
        internal readonly IWorkshopService _workshopService;
        public WorkshopBaseController(IWorkshopService workshopService)
        {
            _workshopService = workshopService;
        }
    }
}
