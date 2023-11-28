﻿using AdviceConsultingSubsystem;
using ApplicationService.MailSettings;
using Models.Entities;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AppService.AdviceConsultingService.Implementation
{
    public class ServiceStaff : OtherService, IServiceStaff
    {
        private readonly IMailService _mail;
        public ServiceStaff(IAdviceConsultingFeature consulting, IFeatureTransaction transaction, IMailService mail) : base(consulting, transaction) 
        {
            _mail = mail;
        }
        public async Task ApproveConsultingTicket(int ticketId)
        {
            await _consulting.Staff.ApproveConsultingTicket(ticketId);
            var ticket = await _consulting.Other.GetConsultingTicketById(ticketId);
            var mailContent = new MailContent()
            {
                Subject = "Consultant Time",
                HtmlMessage = ticket.GgMeetLink
            };
            await _mail.SendEmailAsync(ticket.CustomerEmail, mailContent);
        }

        public async Task AssignTrainer(int trainerId, int ticketId)
        {
            await _consulting.Staff.AssignTrainer(trainerId, ticketId);
            var ticket = await _consulting.Other.GetConsultingTicketById(ticketId);
            var mailContent = new MailContent()
            {
                Subject = "Consultant Time",
                HtmlMessage = ticket.GgMeetLink
            };
            await _mail.SendEmailAsync(ticket.CustomerEmail, mailContent);
        }

        public async Task CancelConsultingTicket(int ticketId)
        {
            await _consulting.Staff.CancelConsultingTicket(ticketId);
        }

        public async Task<ConsultingTicketDetailViewModel> GetConsultingTicketByID(int id)
        {
            return await _consulting.Staff.GetConsultingTicketByID(id);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListAssignedConsultingTicket()
        {
            return await _consulting.Staff.GetListAssignedConsultingTicket();
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListConsultingTicketsByCustomerID(int customerID)
        {
            return await _consulting.Staff.GetListConsultingTicketsByCustomerID (customerID);
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListHandledConsultingTicket()
        {
            return await _consulting.Staff.GetListHandledConsultingTicket();
        }

        public async Task<IEnumerable<ConsultingTicketListViewModel>> GetListNotAssignedConsultingTicket()
        {
            return await _consulting.Staff.GetListNotAssignedConsultingTicket();
        }
    }
}
