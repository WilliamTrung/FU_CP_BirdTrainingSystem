using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class AdviceConsultingProfile : Profile
    {
        public AdviceConsultingProfile()
        {
            Map_DistancePriceServieModel_DistancePrice();
            Map_ConsultingPricePolicyServiceModel_ConsultingPricePolicy();
            Map_ConsultingTypeServiceModel_ConsultingType();
            Map_ConsultingTicketCreateNewModel_ConsultingTicket();
            Map_ConsultingTicketDetailViewModel_ConsultingTicket();
            Map_AdviceConsultingTrainerSlotServiceModel_TrainerSlot();
        }

        private void Map_DistancePriceServieModel_DistancePrice()
        {
            CreateMap<DistancePriceServiceModel, DistancePrice>();
        }

        private void Map_ConsultingPricePolicyServiceModel_ConsultingPricePolicy()
        {
            CreateMap<ConsultingPricePolicyServiceModel, ConsultingPricePolicy>();
        }

        private void Map_ConsultingTypeServiceModel_ConsultingType()
        {
            CreateMap<ConsultingTypeServiceModel, ConsultingType>();
        }

        private void Map_ConsultingTicketCreateNewModel_ConsultingTicket()
        {
            CreateMap<ConsultingTicketCreateNewModel, ConsultingTicket>()
                .ForMember(e => e.AppointmentDate, opt => opt.MapFrom(c => c.AppointmentDate.ToDateTime(new TimeOnly(0, 0, 0))))
                .ForMember(e => e.Status, opt => opt.MapFrom(c => (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove));
        }

        private void Map_ConsultingTicketDetailViewModel_ConsultingTicket()
        {
            CreateMap<ConsultingTicketDetailViewModel, ConsultingTicket>();
        }

        private void Map_AdviceConsultingTrainerSlotServiceModel_TrainerSlot()
        {
            CreateMap<AdviceConsultingTrainerSlotServiceModel, TrainerSlot>()
                .ForMember(e => e.SlotId, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Date.ToDateTime(new TimeOnly(0, 0, 0))))
                .ForMember(e => e.TrainerId, opt => opt.MapFrom(m => m.TrainerId))
                .ForMember(e => e.Status, opt => opt.MapFrom(m => (int)Models.Enum.ConsultingTicket.Status.Confirmed))
                .ForMember(e => e.EntityId, opt => opt.MapFrom(m => m.EntityId))
                .ForMember(e => e.EntityTypeId, opt => opt.MapFrom(m => m.EntityTypeId))
                .ForMember(e => e.Reason, opt => opt.MapFrom(m => "Consulting Customer"));
        }
    }
}
