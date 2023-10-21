using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopTrainerController : WorkshopBaseController, IWorkshopTrainer
    {
        public WorkshopTrainerController(IWorkshopService workshopService) : base(workshopService)
        {
        }

        public Task<IActionResult> GetAssignedClasses([FromQuery] int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAssignedSlots([FromQuery] int workshopClassId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetAssignedWorkshops()
        {
            throw new NotImplementedException();
        }
    }
}
