﻿using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Birds = new HashSet<Bird>();
            ConsultingTickets = new HashSet<ConsultingTicket>();
            CustomerCertificateDetails = new HashSet<CustomerCertificateDetail>();
            CustomerLessonDetails = new HashSet<CustomerLessonDetail>();
            CustomerOnlineCourseDetails = new HashSet<CustomerOnlineCourseDetail>();
            CustomerSectionDetails = new HashSet<CustomerSectionDetail>();
            CustomerWorkshopClasses = new HashSet<CustomerWorkshopClass>();
            Feedbacks = new HashSet<Feedback>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? Status { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<Bird> Birds { get; set; }
        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
        public virtual ICollection<CustomerCertificateDetail> CustomerCertificateDetails { get; set; }
        public virtual ICollection<CustomerLessonDetail> CustomerLessonDetails { get; set; }
        public virtual ICollection<CustomerOnlineCourseDetail> CustomerOnlineCourseDetails { get; set; }
        public virtual ICollection<CustomerSectionDetail> CustomerSectionDetails { get; set; }
        public virtual ICollection<CustomerWorkshopClass> CustomerWorkshopClasses { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
