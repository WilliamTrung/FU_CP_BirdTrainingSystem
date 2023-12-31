﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels
{
    public class OnlineCourseSectionViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ResourceFiles { get; set; }
        public Models.Enum.OnlineCourse.Customer.Section.Status? Status { get; set; }
        public IEnumerable<OnlineCourseLessonViewModel>? Lessons { get; set; } 
    }
}
