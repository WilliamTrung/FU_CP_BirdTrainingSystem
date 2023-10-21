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
        Get workshop classes on selected workshop
        Get workshop class slot details on selected workshop class
        Get workshop class slot detail
        Get workshop policies

         */
        
        //customer
        /*
         Register workshop class
        Get registered workshop classes

         */
        //staff
        /*
         Create workshop class
        Get workshop classes with admin view
        Get workshop class details with admin view
        "Modify workshop slot- change trainer, date and slot"
        "Modify workshop slot- change date and slot"

         */
        //manager
        /*
         Create workshop
        Get workshop detail template
        Modify workshop detail template
        Modify workshop status
        Get workshop status
         */
        //trainer
        /*
         Get assigned workshops
        Get assigned workshop classes
        Get assigned workshop class details

         */
    }
}
