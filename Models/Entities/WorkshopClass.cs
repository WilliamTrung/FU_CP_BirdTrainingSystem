﻿using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class WorkshopClass
    {
        public WorkshopClass()
        {
            CustomerWorkshopClasses = new HashSet<CustomerWorkshopClass>();           
            WorkshopClassDetails = new HashSet<WorkshopClassDetail>();
        }

        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RegisterEndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public string Location { get; set; } = null!;
        public int Status { get; set; }

        public virtual Workshop Workshop { get; set; } = null!;
        public virtual ICollection<CustomerWorkshopClass> CustomerWorkshopClasses { get; set; }
        //public virtual ICollection<WorkshopAttendance> WorkshopAttendances { get; set; }
        public virtual ICollection<WorkshopClassDetail> WorkshopClassDetails { get; set; }
    }
}
