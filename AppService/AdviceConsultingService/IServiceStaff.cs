﻿using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdviceConsultingService
{
    public interface IServiceStaff : IOtherService
    {
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByCustomerID(int customerID);
        Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByStatus(int status);
        Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id);
        Task AssignTrainer(int trainerId, int ticketId);
        Task ApproveConsultingTicket(int ticketId);
        Task CancelConsultingTicket(int ticketId);
    }
}