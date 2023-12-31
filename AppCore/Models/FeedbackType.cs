﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class FeedbackType
    {
        public FeedbackType()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
