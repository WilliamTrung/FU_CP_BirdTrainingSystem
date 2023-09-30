namespace Models.Entities
{
    public partial class Lesson
    {
        public Lesson()
        {
            CustomerLessonDetails = new HashSet<CustomerLessonDetail>();
        }

        public int Id { get; set; }
        public int SectionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Detail { get; set; }
        public string? Video { get; set; }

        public virtual Section Section { get; set; } = null!;
        public virtual ICollection<CustomerLessonDetail> CustomerLessonDetails { get; set; }
    }
}
