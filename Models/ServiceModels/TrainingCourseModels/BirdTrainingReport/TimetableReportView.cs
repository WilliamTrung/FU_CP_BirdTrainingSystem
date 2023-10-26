using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.BirdTrainingReport
{
    public class TimetableReportView
    {
        public int Id { get; set; }
        public string SkillName { get; set; } = null!;
        public string? SkillDescription { get; set; }
        public string BirdName { get; set; } = null!;
        public string BirdSpeciesName { get; set; } = null!;
        public string? BirdColor { get; set; }
        public string? BirdPicture { get; set; }
    }
}
