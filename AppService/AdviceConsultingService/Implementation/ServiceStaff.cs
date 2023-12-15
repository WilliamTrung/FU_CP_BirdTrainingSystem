﻿using AdviceConsultingSubsystem;
using AppCore.Models;
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
        public async Task ApproveConsultingTicket(int ticketId, int distance)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPrice(ticketId, distance);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);
            decimal discountedPrice = price.GetType().GetProperty("DiscountedPrice").GetValue(price, null);
            await _consulting.Staff.ApproveConsultingTicket(ticketId, distance, finalPrice, discountedPrice);
            var ticket = await _consulting.Other.GetConsultingTicketById(ticketId);
            string type = null;
            string meetLink = null;
            if (ticket.OnlineOrOffline == true)
            {
                type = "Online";
                meetLink = ticket.GgMeetLink;
            }
            else
            {
                type = "Offline";
                meetLink = "";
            }

            var mailContent = new MailContent()
            {
                Subject = "Consulting Appointment Information",
                HtmlMessage = $"Dear {ticket.CustomerName}\r\n" +
                "Thank you for using our center's services.\r\n" +
                "Here is your Consulting Appointment Detail: \r\n" +
                $"- Topic: {ticket.ConsultingType}\r\n" +
                $"- Consultants: {ticket.TrainerName}\r\n" +
                $"- Type: {type}\r\n" +
                $"- Time: {ticket.ActualSlotStart}\r\n" +
                $"- Google Meet Link: {meetLink}\r\n" +
                $"- Price: {ticket.Price}\r\n" +
                "If you have any questions, please contact us via email: williamthanhtrungq2@gmail.com\r\n" +
                "Thanks and Regards"
            };
            await _mail.SendEmailAsync(ticket.CustomerEmail, mailContent);
        }

        public async Task AssignTrainer(int trainerId, int ticketId, int distance)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPrice(ticketId, distance);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);
            decimal discountedPrice = price.GetType().GetProperty("DiscountedPrice").GetValue(price, null);
            await _consulting.Staff.AssignTrainer(trainerId, ticketId, distance, finalPrice, discountedPrice);
            var ticket = await _consulting.Other.GetConsultingTicketById(ticketId);
            string type = null;
            if (ticket.OnlineOrOffline == true)
            {
                type = "Online";
            }
            else
            {
                type = "Offline";
            }
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

        public async Task CreateConsultingType(ConsultingTypeCreateNewServiceModel consultingType)
        {
            await _consulting.Staff.CreateConsultingType(consultingType);
        }

        public async Task CreateNewDistancePricePolicy(DistancePricePolicyCreateNewServiceModel distancePricePolicy)
        {
            await _consulting.Staff.CreateNewDistancePricePolicy(distancePricePolicy);
        }

        public async Task CreateNewPricePolicy(ConsultingPricePolicyCreateNewServiceModel pricePolicy)
        {
            await _consulting.Staff.CreateNewConsultingPricePolicy(pricePolicy);
        }

        public async Task DeleteConsultingPricePolicy(int policyId)
        {
            await _consulting.Staff.DeleteConsultingPricePolicy(policyId);
        }

        public async Task DeleteConsultingType(int consultingTypeId)
        {
            await _consulting.Staff.DeleteConsultingType(consultingTypeId);
        }

        public async Task DeleteDistancePricePolicy(int distancePricePolicyId)
        {
            await _consulting.Staff.DeleteDistancePricePolicy(distancePricePolicyId);
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

        public async Task<decimal> PreCalculateConsultantPrice(int ticketId, int distance)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPrice(ticketId, distance);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);

            return finalPrice;
        }

        public async Task UpdateConsultantPricePolicy(ConsultingPricePolicyUpdateServiceModel pricePolicy)
        {
            await _consulting.Staff.UpdateConsultantPricePolicy(pricePolicy);
        }

        public async Task UpdateConsultingType(ConsultingTypeServiceModel consultingType)
        {
            await _consulting.Staff.UpdateConsultingType(consultingType);
        }

        public async Task UpdateDistancePricePolicy(DistancePricePolicyUpdateServiceModel distancePricePolicy)
        {
            await _consulting.Staff.UpdateDistancePricePolicy(distancePricePolicy);
        }
    }
}
