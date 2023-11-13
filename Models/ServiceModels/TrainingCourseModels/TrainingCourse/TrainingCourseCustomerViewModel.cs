using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourse
{
    public class TrainingCourseCustomerViewModel
    {
        public TrainingCourseCustomerViewModel()
        {
            SkillNames = new List<string>();
        }
        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string BirdSpeciesName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int TotalSlot { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<string> SkillNames { get; set; }
    }
}
