using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceStaff : IServiceAll
    {
        Task CreateWorkshopClass(WorkshopClassAddModel workshopClass);
        Task ModifyWorkshopClassDetail(WorkshopClassDetailModifyModel model);
        Task ModifyWorkshopClassDetailTrainer(WorkshopClassDetailTrainerSlotModifyModel model);
        Task ModifyWorkshopClassDetailTrainerSlotOnlu(WorkshopClassDetailTrainerSlotOnlyModifyModel model);

    }
}
