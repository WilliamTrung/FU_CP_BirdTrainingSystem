using Models.Enum.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class ConsultingTicketServiceModel
    {
        public int Id { get; set; }
        public CustomerServiceModel customer { get; set; } = null!;
        public AddressServiceModel Address { get; set; } = null!;
        public ConsultingTypeServiceModel ConsultingType { get; set; } = null!;
        public TrainerServiceModel Trainer { get; set; } = null!;
        public DateTime? ExpectedDate { get; set; }
        public int? ExpectedSlotStart { get; set; }
        public int? ExpectedSlotEnd { get; set; }
        public string ConsultingDetail { get; set; }
        public int Distance { get; set; }
        public Enum.ConsultingTicket.OnlineOrOffline OnlineOrOffline { get; set; }
        public string GgMeetLink { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
        public int ActualEndSlot { get; set; }
        public decimal Price { get; set; }
        public Enum.ConsultingTicket.Status Status { get; set; }
        public ConsultingPricePolicyServiceModel ConsultingPricePolicy { get; set; } = null!;
        public DistancePriceServiceModel DistancePrice { get; set; } = null!;
    }
}
