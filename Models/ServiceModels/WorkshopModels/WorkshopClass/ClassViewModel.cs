using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public DateTime? RegisterEndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public Enum.Workshop.Class.Status Status { get; set; }        
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
    }
}
