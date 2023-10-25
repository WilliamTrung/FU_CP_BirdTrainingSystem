using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels.ConsultingTicket
{
    public class ConsultingTicketCreateNewModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; }
        public string ConsultingType { get; set; }
        public int TrainerId { get; set; }
        public string ConsultingDetail { get; set; }
        public int Distance { get; set; }
        public bool OnlineOrOffline { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }
        public int ActualEndSlot { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int Status { get; set; }
    }
}
