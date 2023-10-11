﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
//[WorkshopClassDetailSlotModify]:
//+ id : int
//+ trainerId : int
//+ slotId : int
//+ date : date
    public class WorkshopClassDetailTrainerSlotModifyModel
    {
        public int Id { get; set; } 
        public int TrainerId { get; set; }
        public int SlotId { get; set; }
        [SP_Validator.DateOnlyValidator]
        public DateTime Date { get; set; }
    }
}