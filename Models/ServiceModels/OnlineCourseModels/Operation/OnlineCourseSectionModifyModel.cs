﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Operation
{
    public class OnlineCourseSectionModifyModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        public string? ResourceFiles { get; set; }
    }
}
