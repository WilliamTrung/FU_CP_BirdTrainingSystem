﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfigModels
{
    public class BR_WorkshopConstant
    {
        public static int StartDateDeadlineAfterRegistrationEnd { get; } = 5;
        public static int DeadlineDateModifySlotDetail { get; } = 3;
        public static int DeadlineDateModifyDetail { get; } = 2;
        public static int MaximumRegisteredCustomer { get; } = 20;
        public static int MinimumRegisteredCustomer { get; } = 10;
    }
}
