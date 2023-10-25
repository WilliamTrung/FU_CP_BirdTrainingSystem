using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class WorkshopModel
    {
        public int Id { get; set; }
        //public WorkshopRefundPolicyModel RefundPolicy { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? Picture { get; set; } = null!;
        public int? RegisterEnd { get; set; } 
        public decimal Price { get; set; }
        public int TotalSlot { get; set; }

    }
}
