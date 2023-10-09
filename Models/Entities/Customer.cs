using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Addresses = new HashSet<Address>();
            Birds = new HashSet<Bird>();
            ConsultingTickets = new HashSet<ConsultingTicket>();
            CustomerCertificateDetails = new HashSet<CustomerCertificateDetail>();
            CustomerLessonDetails = new HashSet<CustomerLessonDetail>();
            CustomerOnlineCourseDetails = new HashSet<CustomerOnlineCourseDetail>();
            CustomerSectionDetails = new HashSet<CustomerSectionDetail>();
            CustomerWorkshopClasses = new HashSet<CustomerWorkshopClass>();
            Feedbacks = new HashSet<Feedback>();
            Transactions = new HashSet<Transaction>();
            WorkshopAttendances = new HashSet<WorkshopAttendance>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int MembershipRankId { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Gender { get; set; }
        public decimal? TotalPayment { get; set; }
        public int Status { get; set; }

        public virtual MembershipRank MembershipRank { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Bird> Birds { get; set; }
        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
        public virtual ICollection<CustomerCertificateDetail> CustomerCertificateDetails { get; set; }
        public virtual ICollection<CustomerLessonDetail> CustomerLessonDetails { get; set; }
        public virtual ICollection<CustomerOnlineCourseDetail> CustomerOnlineCourseDetails { get; set; }
        public virtual ICollection<CustomerSectionDetail> CustomerSectionDetails { get; set; }
        public virtual ICollection<CustomerWorkshopClass> CustomerWorkshopClasses { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<WorkshopAttendance> WorkshopAttendances { get; set; }
    }
}
