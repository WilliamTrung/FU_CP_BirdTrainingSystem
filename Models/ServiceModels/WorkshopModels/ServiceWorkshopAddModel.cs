using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class ServiceWorkshopAddModel
    {
        public WorkshopPricePolicy PricePolicy { get; set; } = null!;
        public WorkshopRefundPolicy RefundPolicy { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public IFormFile Picture { get; set; } = null!;
        public int? RegisterEnd { get; set; }
        public decimal Price { get; set; }
        public int TotalSlot { get; set; }
        public Enum.Workshop.Status Status { get; set; }
    }
}
