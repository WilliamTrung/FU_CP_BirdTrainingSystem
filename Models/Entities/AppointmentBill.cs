using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class AppointmentBill
    {
        public AppointmentBill()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int? TotalTime { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
