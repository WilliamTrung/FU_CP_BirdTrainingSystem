namespace Models.Entities
{
    public partial class ConsultingType
    {
        public ConsultingType()
        {
            ConsultingTickets = new HashSet<ConsultingTicket>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
    }
}
