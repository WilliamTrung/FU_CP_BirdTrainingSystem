﻿using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class ConsultingTicketRepository : GenericRepository<ConsultingTicket>, IConsultingTicketRepository
    {
        public ConsultingTicketRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
