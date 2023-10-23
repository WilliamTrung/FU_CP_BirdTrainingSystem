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
            Map_ConsultingTicket_ConsultingTicketServiceModel();
            Map_DistancePrice_DistancePriceServieModel();
            Map_ConsultingTicket_ConsultingTicketCreateNewModel();
            Map_ConsultingTicket_ConsultingTicketDetailViewModel();
            Map_ConsultingPricePolicy_ConsultingPricePolicyServiceModel();
            Map_ConsultingType_ConsultingTypeServiceModel();
        }

        private void Map_ConsultingTicket_ConsultingTicketServiceModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketServiceModel>();
        }

        private void Map_DistancePrice_DistancePriceServieModel()
        {
            CreateMap<DistancePrice, DistancePriceServiceModel>();
        }

        private void Map_ConsultingTicket_ConsultingTicketCreateNewModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketCreateNewModel>();
        }

        private void Map_ConsultingTicket_ConsultingTicketDetailViewModel()
        {
            CreateMap<ConsultingTicket, ConsultingTicketDetailViewModel>();
        }

        private void Map_ConsultingPricePolicy_ConsultingPricePolicyServiceModel()
        {
            CreateMap<ConsultingPricePolicy, ConsultingPricePolicyServiceModel>();
        }

        private void Map_ConsultingType_ConsultingTypeServiceModel()
        {
            CreateMap<ConsultingType, ConsultingTypeServiceModel>();
        }
    }
}
