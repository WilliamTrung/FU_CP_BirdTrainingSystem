using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureCustomer : IFeatureCustomer
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SendConsultingTicket(ConsultingTicketServiceModel consultingTicket)
        {
            var entity = _mapper.Map<ConsultingTicket>(consultingTicket);
            await _unitOfWork.ConsultingTicketRepository.Add(entity);
            //Add new Consulting Ticket
        }

        public async Task<IEnumerable<ConsultingTicketServiceModel>> GetListConsultingTicket(int customerId)
        {
            var entites = await _unitOfWork.ConsultingTicketRepository.Get(x => x.CustomerId == customerId);
            var models = new List<ConsultingTicketServiceModel>();
            foreach (var entity in entites)
            {
                var model = _mapper.Map<ConsultingTicketServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }
    }
}
