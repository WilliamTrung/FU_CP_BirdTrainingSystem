﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.WorkshopClass
{
//    [WorkshopClassDetailModify]:
//+ id : int
//+ detail : string
    public class WorkshopClassDetailModifyModel
    {
        public int Id { get; set; }
        public string Detail { get; set; } = null!;
    }
}
