using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopManagerController : WorkshopBaseController, IWorkshopManager
    {
        public WorkshopManagerController(IWorkshopService workshopService) : base(workshopService)
        {
        }
    }
}
