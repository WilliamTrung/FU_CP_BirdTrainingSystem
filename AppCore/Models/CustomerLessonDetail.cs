﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class CustomerLessonDetail
    {
        public int CustomerId { get; set; }
        public int LessionId { get; set; }
        public bool? IsComplete { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual Lesson Lession { get; set; } = null!;
    }
}
