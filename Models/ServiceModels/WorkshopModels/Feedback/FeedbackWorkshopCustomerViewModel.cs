using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.Feedback
{
    public class FeedbackWorkshopCustomerViewModel
    {
        public string? Avatar { get; set; }
        public string Name { get; set; } = null!;
        public string? Feedback { get; set; }
        public int? Rating { get; set; }
        public string Membership { get; set; } = null!;

    }
}
