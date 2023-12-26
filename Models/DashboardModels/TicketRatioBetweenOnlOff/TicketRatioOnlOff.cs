using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels.TicketRatioBetweenOnlOff
{
    public class Data
    {
        public Models.Enum.Month Label { get; set; }
        public double Y { get; set; }
    }
    public class TicketRatioOnlOff
    {
        public TicketRatioOnlOff()
        {
            Online = new List<Data>();
            Offline = new List<Data>();
        }
        public List<Data> Online { get; set; } = null!;
        public List<Data> Offline { get; set; } = null!;
    }
}
