using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels.TicketRatioBetweenOnlOff
{
    public class Data
    {
        public string Label { get; set; } = null!;
        public double Y { get; set; }
    }
    public class TicketRatioOnlOff
    {
        public TicketRatioOnlOff()
        {
            Online = new List<Data>();
            Offline = new List<Data>();
        }
        List<Data> Online { get; set; } = null!;
        List<Data> Offline { get; set; } = null!;
    }
}
