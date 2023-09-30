namespace Models.Entities
{
    public partial class CustomerOnlineCourseDetail
    {
        public int CustomerId { get; set; }
        public int OnlineCourseId { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual OnlineCourse OnlineCourse { get; set; } = null!;
    }
}
