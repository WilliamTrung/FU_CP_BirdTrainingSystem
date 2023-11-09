using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.Feedback
{
    public class FeedbackWorkshopCustomerAddModel
    {
        public int WorkshopId { get; set; }
        public string? Feedback { get; set; }
        public int Rating { get; set; }
        
    }
}
