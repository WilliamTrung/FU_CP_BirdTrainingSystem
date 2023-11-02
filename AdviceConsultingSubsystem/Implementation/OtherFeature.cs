using AppCore.Models;
using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Enum.Trainer;
using Models.ServiceModels;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class OtherFeature : IOtherFeature
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public OtherFeature(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketById(int id)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == id);
            var model = _mapper.Map<ConsultingTicketDetailViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get();
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingPricePolicyServiceModel>> GetConsultingPricePolicy()
        {
            var entities = await _unitOfWork.ConsultingPricePolicyRepository.Get();
            var models = new List<ConsultingPricePolicyServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingPricePolicyServiceModel>(entity);
                models.Add(model);  
            }

            return models;
        }

        public async Task<IEnumerable<DistancePriceServiceModel>> GetDistancePricePolicy()
        {
            var entities = await _unitOfWork.DistancePriceRepository.Get();
            var models = new List<DistancePriceServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<DistancePriceServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingTypeServiceModel>> GetConsutlingType()
        {
            var entities = await _unitOfWork.ConsultingTypeRepository.Get();
            var models = new List<ConsultingTypeServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTypeServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }
    }
}
