using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class WorkshopAddModel
    {
//[WorkshopAdd]:
//+ title : string
//+ description : string
//+ picture : image(1)
//+ registerEnd : int
//+ Price : money
//+ totalSlot : int
       
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Picture { get; set; } = null!;
        public int? RegisterEnd { get; set; }
        public decimal Price { get; set; }
        public int TotalSlot { get; set; }
    }
}
