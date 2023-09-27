using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class AppointmentBill
    {
        public AppointmentBill()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public int? TotalSlot { get; set; }
        public decimal? TotalPrice { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
