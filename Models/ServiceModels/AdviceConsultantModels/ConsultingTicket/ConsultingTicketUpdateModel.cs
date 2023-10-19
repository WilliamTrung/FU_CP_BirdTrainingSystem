using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketUpdateModel
    {
        public int Id { get; set; }
        public TrainerServiceModel Trainer { get; set; } = null!;
        public string GgMeetLink { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
        public int ActualEndSlot { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int Status { get; set; }
    }
}
