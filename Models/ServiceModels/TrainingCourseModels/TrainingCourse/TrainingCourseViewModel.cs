using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.TrainingCourse
{
    public class TrainingCourseViewModel
    {
        public TrainingCourseViewModel()
        {
            SkillNames= new List<string>();
            RegisteredCustomer = new List<int>();
        }
        public int Id { get; set; }
        public int BirdSpeciesId { get; set; }
        public string BirdSpeciesName { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int TotalSlot { get; set; }
        public decimal TotalPrice { get; set; }
        public List<string> SkillNames { get; set; }
        public List<int> RegisteredCustomer { get; set; }
    }
}
