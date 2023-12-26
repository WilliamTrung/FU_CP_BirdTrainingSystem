using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels.Top
{
    public class TopTrainerDataPoint
    {
        public string Label { get; set; } = null!;
        public int Y { get; set; }
    }
    public class TopTrainerModel
    {
        public string Name { get; set; } = null!;
        public List<TopTrainerDataPoint> DataPoints { get; set; } = new List<TopTrainerDataPoint>();
    }
}
