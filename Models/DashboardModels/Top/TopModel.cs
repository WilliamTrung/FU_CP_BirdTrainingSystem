using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels.Top
{
   
    public class TopModel
    {
        
        public string Title { get; set; } = null!;
        public List<Model> DataPoints = new List<Model>();
    }
    public class Model
    {
        public decimal Y { get; set; }
        public string Label { get; set; } = null!;//name or title of service
    }
}
