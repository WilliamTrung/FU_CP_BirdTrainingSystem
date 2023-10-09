using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class ConsultingTicketRepository : GenericRepository<ConsultingTicket>, IConsultingTicketRepository
    {
        public ConsultingTicketRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
