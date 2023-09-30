namespace Models.Entities
{
    public partial class Address
    {
        public Address()
        {
            ConsultingTickets = new HashSet<ConsultingTicket>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? AddressDetail { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<ConsultingTicket> ConsultingTickets { get; set; }
    }
}
