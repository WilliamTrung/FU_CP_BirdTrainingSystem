namespace AppCore.Models
{
    public partial class WorkshopClassDetail
    {
        public int WorkshopClassId { get; set; }
        public int TrainerId { get; set; }
        public int DaySlotId { get; set; }
        public string? Detail { get; set; }

        public virtual TrainerSlot DaySlot { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual WorkshopClass WorkshopClass { get; set; } = null!;
    }
}
