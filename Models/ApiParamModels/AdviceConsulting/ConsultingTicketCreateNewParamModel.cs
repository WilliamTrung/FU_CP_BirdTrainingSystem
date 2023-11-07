using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.AdviceConsulting
{
    public class ConsultingTicketCreateNewParamModel
    {
        public int TrainerId { get; set; }
        public int? AddressId { get; set; }
        public int ConsultingTypeId { get; set; }
        public string? ConsultingDetail { get; set; }
        public bool OnlineOrOffline { get; set; }
        public DateTime AppointmentDate { get; set; }
        public int ActualSlotStart { get; set; }

        public ConsultingTicketCreateNewModel Convert_ParamModel_ServiceModel(int customerId)
        {
            var model = new ConsultingTicketCreateNewModel()
            {
                TrainerId = TrainerId,
                AddressId = AddressId,
                ConsultingTypeId = ConsultingTypeId,
                ConsultingDetail = ConsultingDetail,
                OnlineOrOffline = OnlineOrOffline,
                AppointmentDate = AppointmentDate,
                ActualSlotStart = ActualSlotStart,
                CustomerId = customerId
            };

            return model;
        }
    }
}
