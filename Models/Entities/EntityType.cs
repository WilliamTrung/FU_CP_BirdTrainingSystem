namespace Models.Entities
{
    public partial class EntityType
    {
        public EntityType()
        {
            Feedbacks = new HashSet<Feedback>();
            TrainerSlots = new HashSet<TrainerSlot>();
            Transactions = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<TrainerSlot> TrainerSlots { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
