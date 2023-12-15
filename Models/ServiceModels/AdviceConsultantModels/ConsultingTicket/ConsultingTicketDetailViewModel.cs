using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketDetailViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerEmail { get; set; }
        public decimal? CustomerPhone { get; set; }
        public string? CustomerAvatar { get; set; }
        public string AddressDetail { get; set; } = null!;
        public string ConsultingType { get; set; } = null!;
        public string TrainerName { get; set; } = null!;
        public string? TrainerAvatar { get; set;}
        public string? ConsultingDetail { get; set; }
        public int? Distance { get; set; }
        public bool OnlineOrOffline { get; set; }
        public string? GgMeetLink { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int SlotStartId { get; set; }
        public string ActualSlotStart { get; set; }
        public string? ActualEndSlot { get; set; }
        public string? Evidence { get; set; }
        public decimal? Price { get; set; }
        public Models.Enum.ConsultingTicket.Status Status { get; set; }
    }
}
