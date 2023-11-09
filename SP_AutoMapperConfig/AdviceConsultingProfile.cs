using AppRepository.UnitOfWork;
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
            Map_DistancePrice_DistancePriceServieModel();
            Map_ConsultingPricePolicy_ConsultingPricePolicyServiceModel();
            Map_ConsultingType_ConsultingTypeServiceModel();
            Map_ConsultingTicketCreateNewModel_ConsultingTicket();
            Map_ConsultingTicket_ConsultingTicketDetailViewModel();
            Map_ConsultingTicket_ConsultingTicketListViewModel();
            Map_AdviceConsultingTrainerSlotServiceModel_TrainerSlot();
            Map_CreateNewAddressServiceModel_Address();
            Map_Address_AddressServiceModel();
        }

        private void Map_DistancePrice_DistancePriceServieModel()
        {
            CreateMap<DistancePrice, DistancePriceServiceModel>();
        }

        private void Map_ConsultingPricePolicy_ConsultingPricePolicyServiceModel()
        {
            CreateMap<ConsultingPricePolicy, ConsultingPricePolicyServiceModel>()
                .ForMember(e => e.Price, opt => opt.MapFrom(c => c.Price));
        }

        private void Map_ConsultingType_ConsultingTypeServiceModel()
        {
            CreateMap<ConsultingType, ConsultingTypeServiceModel>()
                .ForMember(e => e.Name, opt => opt.MapFrom(c => c.Name));
        }

        private void Map_ConsultingTicketCreateNewModel_ConsultingTicket()
        {
            CreateMap<ConsultingTicketCreateNewModel, ConsultingTicket>()
                .ForMember(e => e.AddressId, opt => opt.MapFrom(c => c.AddressId))
                .ForMember(e => e.TrainerId, opt => opt.MapFrom(c => c.TrainerId))
                .ForMember(e => e.ConsultingDetail, opt => opt.MapFrom(c => c.ConsultingDetail))
                .ForMember(e => e.OnlineOrOffline, opt => opt.MapFrom(c => c.OnlineOrOffline))
                .ForMember(e => e.AppointmentDate, opt => opt.MapFrom(c => c.AppointmentDate))
                .ForMember(e => e.Status, opt => opt.MapFrom(c => (int)Models.Enum.ConsultingTicket.Status.WaitingForApprove));
        }

        private void Map_ConsultingTicket_ConsultingTicketDetailViewModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketDetailViewModel>();
        }

        private void Map_ConsultingTicket_ConsultingTicketListViewModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketListViewModel>();
        }
        private void Map_AdviceConsultingTrainerSlotServiceModel_TrainerSlot()
        {
            CreateMap<AdviceConsultingTrainerSlotServiceModel, TrainerSlot>()
                .ForMember(e => e.SlotId, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Date.ToDateTime(new TimeOnly())))
                .ForMember(e => e.TrainerId, opt => opt.MapFrom(m => m.TrainerId))
                .ForMember(e => e.Status, opt => opt.MapFrom(m => (int)Models.Enum.ConsultingTicket.Status.Confirmed))
                .ForMember(e => e.EntityId, opt => opt.MapFrom(m => m.EntityId))
                .ForMember(e => e.EntityTypeId, opt => opt.MapFrom(m => m.EntityTypeId))
                .ForMember(e => e.Reason, opt => opt.MapFrom(m => "Consulting Customer"));
        }

        private void Map_CreateNewAddressServiceModel_Address()
        {
            CreateMap<CreateNewAddressServiceModel, Address>();
        }

        private void Map_Address_AddressServiceModel()
        {
            CreateMap<Address, CreateNewAddressServiceModel>();
        }
    }
}
