using Models.Enum.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class ConsultingTicket
    {
        public int Id { get; set; }
        public Customer customer { get; set; } = null!;
        public Address Address { get; set; } = null!;
        public ConsultingType ConsultingType { get; set; } = null!;
        public Trainer Trainer { get; set; } = null!;
        public DateTime? ExpectedDate { get; set; }
        public int? ExpectedSlotStart { get; set; }
        public int? ExpectedSlotEnd { get; set; }
        public string? ConsultingDetail { get; set; }
        public int? Distance { get; set; }
        public Enum.ConsultingTicket.OnlineOrOffline OnlineOrOffline { get; set; }
        public string? GgMeetLink { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? ActualSlotStart { get; set; }
        public int? ActualEndSlot { get; set; }
        public decimal? Price { get; set; }
        public Enum.ConsultingTicket.Status Status { get; set; }
        public ConsultingPricePolicy ConsultingPricePolicy { get; set; } = null!;
        public DistancePrice DistancePrice { get; set; } = null!;
    }
}
