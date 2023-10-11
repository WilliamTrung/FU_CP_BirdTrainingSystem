using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureStaff : IFeatureStaff
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ConsultingTicketServiceModel>> GetListConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get();
            var models = new List<ConsultingTicketServiceModel>();
            foreach (var entity in entities) 
            {
                var model = _mapper.Map<ConsultingTicketServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task<IEnumerable<ConsultingTicketServiceModel>> GetListConsultingTicketsByCustomerID(int customerID)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(x => x.CustomerId == customerID);
            var models = new List<ConsultingTicketServiceModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<ConsultingTicketServiceModel>(entity);
                models.Add(model);
            }

            return models;
        }

        public async Task CreateAppointment (ConsultingTicketServiceModel consultingTicket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(consultingTicket.Id));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            if (entity.AppointmentDate == null)
            {
                var appointmentDate = await _unitOfWork.TrainerSlotRepository.GetFirst(x => x.Date.Equals(entity.AppointmentDate));
                if (appointmentDate == null)
                {
                    throw new KeyNotFoundException($"{nameof(appointmentDate)} not found for Date: {entity.AppointmentDate}");
                }
                appointmentDate.Date = consultingTicket.AppointmentDate;
                await _unitOfWork.TrainerSlotRepository.Update(appointmentDate);
            }
            else
            {
                entity.AppointmentDate = consultingTicket.AppointmentDate;
                await _unitOfWork.ConsultingTicketRepository.Update(entity);
            }
        }

        public async void SetConsultingTicketStatus(ConsultingTicketServiceModel consultingTicket)
        {
            var entity = await _unitOfWork.ConsultingTicketRepository.GetFirst(x => x.Id.Equals(consultingTicket.Id));
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(entity)} not found for id: {consultingTicket.Id}");
            }

            //Convert   
        }
    }
}
