using AppService.WorkshopService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    [Route("api/workshop")]
    [ApiController]
    public class WorkshopController : ControllerBase
    {
        private readonly IWorkshopService _workshopService;
        public WorkshopController(IWorkshopService workshopService) { 
            _workshopService = workshopService;
        }
        //all roles
        /*
         Get workshops
         */
        //staff
        //manager
        //trainer
    }
}
