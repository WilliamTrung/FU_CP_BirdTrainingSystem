using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.Bird
{
    public class BirdAddModel
    {
        public int CustomerId { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}
