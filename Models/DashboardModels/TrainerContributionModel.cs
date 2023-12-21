using Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class TrainerContributionModel
    {
        public TrainerModel Trainer { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public int SlotCount { get; set; }
    }
}
