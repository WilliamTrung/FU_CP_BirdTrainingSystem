using Microsoft.AspNetCore.Http;
using Models.ServiceModels.WorkshopModels;
using SP_Validator;
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
        [SP_Validator.PositiveNumber]
        public int RegisterEnd { get; set; }
        [SP_Validator.PositiveNumber]
        public decimal Price { get; set; }
        [SP_Validator.PositiveNumber]
        public int TotalSlot { get; set; }
        //public string Location { get; set; } = null!;
        [SP_Validator.PositiveNumber]
        public int MinimumRegistration { get; set; }
        [SP_Validator.PositiveNumber]
        public int MaximumRegistration { get; set; }

        public WorkshopAddModel ToWorkshopAddModel(string picture)
        {
            return new WorkshopAddModel
            {
                Description = this.Description,
                Title = this.Title,
                RegisterEnd = this.RegisterEnd,
                Price = this.Price,
                TotalSlot = this.TotalSlot,
                Picture = picture,
                //Location = this.Location,
                MinimumRegistration = this.MinimumRegistration,
                MaximumRegistration = this.MaximumRegistration,
            };
        }
    }
}
