using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DashboardModels
{
    public class DashboardConsultingTicket
    {
        //total quantity of ticket
        //new ticket <=> unhandled ticket
        //handled ticket vs total ticket (up to now) ratio (handled ticket is ticket that status == cancelled & finished & approved <=> status != waitingForApprove)
        public int TotalAmount { get; set; }
        public int UnhandledTicket { get; set; }
        public int HandledTicket { get; set; }
        public float HandledRatio { get; set; }
    }
}
