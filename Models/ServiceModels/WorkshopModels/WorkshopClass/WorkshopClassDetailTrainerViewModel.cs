using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class WorkshopClassDetailTrainerViewModel : WorkshopClassDetailViewModel
    {
        public string Title { get; set; } = null!;
        public string? Location { get; set; }
    }
}
