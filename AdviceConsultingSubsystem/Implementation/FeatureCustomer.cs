using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
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

        public async Task SendConsultingTicket(ConsultingTicketCreateNewModel consultingTicket)
        {
            if (consultingTicket.Trainer == null)
            {
                consultingTicket.Status = 1;
            }
            else
            {
                consultingTicket.Status = 2;
            }

            var entity = _mapper.Map<ConsultingTicket>(consultingTicket);
            await _unitOfWork.ConsultingTicketRepository.Add(entity);
            //Add new Consulting Ticket
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketByCustomerID(int customerId)
        {
            var entites = await _unitOfWork.ConsultingTicketRepository.Get(x => x.CustomerId == customerId);
            var models = new List<ConsultingTicketListViewModel>();
            foreach (var entity in entites)
            {
                var model = _mapper.Map<ConsultingTicketListViewModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id == id);
            var model = _mapper.Map<ConsultingTicketDetailViewModel>(entity);
            return model;
        }
    }
}
