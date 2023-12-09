using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Workshop
    {
        public Workshop()
        {
            WorkshopClasses = new HashSet<WorkshopClass>();
            WorkshopDetailTemplates = new HashSet<WorkshopDetailTemplate>();
        }

        public int Id { get; set; }
        //public int WorkshopRefundPolicyId { get; set; }
        public string Title { get; set; } = null!;        
        public int MinimumRegistration { get; set; }
        public int MaximumRegistration { get; set; }
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? RegisterEnd { get; set; }
        public decimal Price { get; set; }
        public int TotalSlot { get; set; }
        public int Status { get; set; }

        //public virtual WorkshopRefundPolicy WorkshopRefundPolicy { get; set; } = null!;
        public virtual ICollection<WorkshopClass> WorkshopClasses { get; set; }
        public virtual ICollection<WorkshopDetailTemplate> WorkshopDetailTemplates { get; set; }
    }
}
