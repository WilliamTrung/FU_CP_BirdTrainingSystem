using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse
{
    public class BirdTrainingCourseViewModel
    {
        public int Id { get; set; } //hidden
        public string TrainingCourseTitle { get; set; } = null!;
        public string? TrainingCoursePicture { get; set; }
        public int TotalSlot { get; set; }
        public string? RegisteredDate { get; set; }
        public string? StartTrainingDate { get; set; }
        public Models.Enum.BirdTrainingCourse.Status Status { get; set; }
    }
}
