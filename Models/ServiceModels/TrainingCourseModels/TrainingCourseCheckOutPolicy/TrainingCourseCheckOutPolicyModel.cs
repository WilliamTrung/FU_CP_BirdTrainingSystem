using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy
{
    public class TrainingCourseCheckOutPolicyModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float ChargeRate { get; set; }
        public Models.Enum.TCCheckOutPolicy.Status Status { get; set; }
    }
}
