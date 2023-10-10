using AppRepository.UnitOfWork;
using AutoMapper;
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

        public async Task<IEnumerable<ConsultingTicket>> GetListConsultingTicket()
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(expression: null, "ConsultingType", "Customer");
            var models = _mapper.Map<IEnumerable<ConsultingTicket>>(entities);
            return models;
        }

        public async Task<IEnumerable<ConsultingTicket>> GetListConsultingTicketsByCustomerID(int customerID)
        {
            var entities = await _unitOfWork.ConsultingTicketRepository.Get(expression: x => x.CustomerId == customerID);
            var models = _mapper.Map<IEnumerable<ConsultingTicket>>(entities);
            return models;
        }

        public void ReplyCustomerConsultingTicket (ConsultingTicket consultingTicket)
        {
            throw new NotImplementedException();
        } 

        public async Task<ConsultingTicket> CreateAppointment (ConsultingTicket consultingTicket, DateTime appointmentDate,
            int actualSlotStart, int actualEndSlot, Trainer trainer)
        {
            throw new NotImplementedException();

            //consultingTicket.AppointmentDate = appointmentDate;
            //consultingTicket.ActualSlotStart = actualSlotStart;
            //consultingTicket.ActualEndSlot = actualEndSlot;
            //consultingTicket.Trainer = trainer;

            //var entities = _unitOfWork.ConsultingTicketRepository.Update();
            //var models = _mapper.Map<IEnumerable<ConsultingTicket>>(entities);
            //return models;
        }

        public void SetConsultingTicketStatus(ConsultingTicket consultingTicket, int status)
        {
            consultingTicket.Status = status;
        }

        //Staff chon trainer ranh -> Co nen lam 1 function rieng trong day hay tao 1 file rieng cho slot ranh
    }
}
