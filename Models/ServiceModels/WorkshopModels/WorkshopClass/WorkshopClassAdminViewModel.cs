﻿using Models.ServiceModels.SlotModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
    public class WorkshopClassAdminViewModel
    {
        public int Id { get; set; }
        public int WorkshopId { get; set; }
        public int RegisterPeriod { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime RegisterEndDate { get; set; }
        public RegistrationAmountModel? RegistrationAmount { get; set; }
        public int MinimumRegistration { get; set; }
        public int MaximumRegistration { get; set; }
        public string Location { get; set; } = null!;
        public Models.Enum.Workshop.Class.Status Status { get; set; }
    }
}
