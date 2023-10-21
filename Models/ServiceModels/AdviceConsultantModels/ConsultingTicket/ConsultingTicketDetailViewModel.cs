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
        public CustomerServiceModel customer { get; set; } = null!;
        public AddressServiceModel Address { get; set; } = null!;
        public ConsultingTypeServiceModel ConsultingType { get; set; } = null!;
        public TrainerServiceModel Trainer { get; set; } = null!;
        public string ConsultingDetail { get; set; }
        public int Distance { get; set; }
        public bool OnlineOrOffline { get; set; }
        public string GgMeetLink { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
        public int ActualEndSlot { get; set; }
        public decimal Price { get; set; }
        public int Status { get; set; }
    }
}
