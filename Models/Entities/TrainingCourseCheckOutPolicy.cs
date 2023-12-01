using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class TrainingCourseCheckOutPolicy
    {
        public TrainingCourseCheckOutPolicy()
        {
        }
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public float ChargeRate { get; set; }
        public int Status { get; set; }
        public virtual ICollection<BirdTrainingCourse>? BirdTrainingCourses { get; set; }
    }
}
