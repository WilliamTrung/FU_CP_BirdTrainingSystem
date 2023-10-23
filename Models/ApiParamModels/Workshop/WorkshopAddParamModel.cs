using Microsoft.AspNetCore.Http;
using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Workshop
{
    public class WorkshopAddParamModel
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public List<IFormFile> Pictures { get; set; } = null!;
        public int? RegisterEnd { get; set; }
        public decimal Price { get; set; }
        public int TotalSlot { get; set; }

        public WorkshopAddModel ToWorkshopAddModel(string picture)
        {
            return new WorkshopAddModel
            {
                Description = this.Description,
                Title = this.Title,
                RegisterEnd = this.RegisterEnd,
                Price = this.Price,
                TotalSlot = this.TotalSlot,
                Picture = picture
            };
        }
    }
}
