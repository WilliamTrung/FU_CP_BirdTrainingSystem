namespace Models.Entities
{
    public partial class WorkshopPricePolicy
    {
        public WorkshopPricePolicy()
        {
            Workshops = new HashSet<Workshop>();
        }

        public int Id { get; set; }
        public int? TotalWorkshop { get; set; }
        public float? Discount { get; set; }

        public virtual ICollection<Workshop> Workshops { get; set; }
    }
}
