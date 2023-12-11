using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class WorkshopClassModifyModel
    {
        public int Id { get; set; }
        public DateOnly? StartTime { get; set; }
        public string? Location { get; set; }
    }
}
