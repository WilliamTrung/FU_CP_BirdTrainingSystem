using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.TrainingCourseModels.Bird
{
    public class BirdSpeciesAddModel
    {
        //{
        //    "id": 0,
        //    "name": "sparrow",
        //    "shortDetail": "A friendly bird, not consume any thread to people."
        //}
        public string Name { get; set; } = null!;
        public string? ShortDetail { get; set; }
    }
}
