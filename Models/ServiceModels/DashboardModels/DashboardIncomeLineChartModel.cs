using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.DashboardModels
{
    public class DashboardIncomeLineChartModel
    {
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public List<decimal> Data { get; set; } = new List<decimal>();
    }
}
