using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class CampaignModel
    {
        public decimal PercentRevenueFromLastMonth { get; set; }
        public decimal RevenueInMonth { get; set; }
        public decimal RevenueInYear { get; set; }
    }
}
