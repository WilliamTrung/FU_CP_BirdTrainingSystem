using AppService.WorkshopService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Workshop;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.WorkshopModels.WorkshopClass;

namespace BirdTrainingCenterAPI.Controllers.Workshop
{
    public class WorkshopStaffController : WorkshopBaseController, IWorkshopStaff
    {
        public WorkshopStaffController(IWorkshopService workshopService) : base(workshopService)
        {
        }

        public Task<IActionResult> CreateWorkshopClass([FromBody] WorkshopClassAddModel workshopClass)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetClassesByWorkshop([FromQuery] int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> GetDetailsByClass([FromQuery] int workshopClassId)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> ModifyTrainerForDetail([FromBody] WorkshopClassDetailTrainerSlotModifyModel workshopClassDetail)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> ModifyTrainerForDetailSlot([FromBody] WorkshopClassDetailTrainerSlotOnlyModifyModel workshopClassDetail)
        {
            throw new NotImplementedException();
        }
    }
}
