using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy
{
    public class PolicyAddModel
    {
        public string Name { get; set; } = null!;
        public float ChargeRate { get; set; }
    }
}
