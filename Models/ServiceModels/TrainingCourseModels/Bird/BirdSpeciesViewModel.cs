using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.Bird
{
    public class BirdSpeciesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ShortDetail { get; set; }
    }
}
