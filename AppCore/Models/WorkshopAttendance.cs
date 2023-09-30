namespace AppCore.Models
{
    public partial class WorkshopAttendance
    {
        public int Id { get; set; }
        public DateTime? AttendDate { get; set; }
        public int CustomerId { get; set; }
        public int WorkshopClassId { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual WorkshopClass WorkshopClass { get; set; } = null!;
    }
}
