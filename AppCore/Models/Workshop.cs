namespace AppCore.Models
{
    public partial class Workshop
    {
        public Workshop()
        {
            WorkshopClasses = new HashSet<WorkshopClass>();
        }

        public int Id { get; set; }
        public int WorkshopPricePolicyId { get; set; }
        public int WorkshopRefundPolicyId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string? Picture { get; set; }
        public int? RegisterEnd { get; set; }
        public decimal? Price { get; set; }
        public int? TotalSlot { get; set; }
        public int? Status { get; set; }

        public virtual WorkshopPricePolicy WorkshopPricePolicy { get; set; } = null!;
        public virtual WorkshopRefundPolicy WorkshopRefundPolicy { get; set; } = null!;
        public virtual ICollection<WorkshopClass> WorkshopClasses { get; set; }
    }
}
