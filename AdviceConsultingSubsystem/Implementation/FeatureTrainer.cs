using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.AdviceConsultantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureTrainer : IFeatureTrainer
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultingTicketServiceModel>> ViewAssignedAppointment (int id)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(expression: x => x.Trainer.Id == id, "Customer");
            var models = _mapper.Map<IEnumerable<ConsultingTicketServiceModel>>(entities);
            return models;
        }

    }
}
