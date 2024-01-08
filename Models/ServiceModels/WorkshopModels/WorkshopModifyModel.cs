using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class WorkshopModifyModel
    {
        public int Id { get; set; }
        //public string? Location { get; set; }
        public int? MinimumRegistration { get; set; } 
        public int? MaximumRegistration { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } 
        public string? Picture { get; set; }
        public int? RegisterEnd { get; set; }
        public decimal? Price { get; set; }
        public int? TotalSlot { get; set; }
    }
}
