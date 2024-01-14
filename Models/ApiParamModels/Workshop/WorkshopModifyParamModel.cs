using Microsoft.AspNetCore.Http;
using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Workshop
{
    public class WorkshopModifyParamModel
    {
        public int Id { get; set; }
        //public string? Location { get; set; }
        [SP_Validator.PositiveNumber]
        public int? MinimumRegistration { get; set; }
        [SP_Validator.PositiveNumber]
        public int? MaximumRegistration { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<IFormFile>? Pictures { get; set; }
        [SP_Validator.PositiveNumber]
        public int? RegisterEnd { get; set; }
        [SP_Validator.PositiveNumber]
        public decimal? Price { get; set; }
        [SP_Validator.PositiveNumber]
        public int? TotalSlot { get; set; }

        public WorkshopModifyModel ToWorkshopModifyModel(string? picture)
        {
            if(Description != null && Description.Trim() == string.Empty)
            {                
                Description = null;
            }
            return new WorkshopModifyModel
            {
                Id = this.Id,
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
