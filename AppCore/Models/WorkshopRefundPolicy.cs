namespace AppCore.Models
{
    public partial class WorkshopRefundPolicy
    {
        public WorkshopRefundPolicy()
        {
            Workshops = new HashSet<Workshop>();
        }

        public int Id { get; set; }
        public int? TotalDayBeforeStart { get; set; }
        public float? RefundRate { get; set; }

        public virtual ICollection<Workshop> Workshops { get; set; }
    }
}
