using AdviceConsultingSubsystem;
using AppCore.Models;
using ApplicationService.MailSettings;
using Models.DashboardModels.TicketRatioBetweenOnlOff;
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

        private string createHtmlMessage(string customerrName, string topic, string trainerName, string type, string slotStart, string link, decimal price)
        {
            string ggLink = link != null ? $"<h3>Google Meet Link: {link}</h3> <br/> " : "";
            string message = $"<h3>Dear {customerrName}, <h3>Thank you for using our center's services.</h3> <br/>" +
                $"<h3>Here is your Consulting Appointment Detail:</h3> <br/>" +
                $"<h3>Topic: {topic}</h3> <br/> " +
                $"<h3>Consultants: {trainerName}</h3> <br/> " +
                $"<h3>Type: {type}</h3> <br/>" +
                $"<h3>Time: {slotStart}</h3> <br/>" +
                ggLink +
                $"<h3>Price: {price} VND</h3> <br/> " +
                $"<h3>If you have any questions, please contact us via email: williamthanhtrungq2@gmail.com </h3> <br/> " +
                "<h3>Thanks and Regards</h3>"; 
            return message;
        }

        public async Task ApproveConsultingTicket(int ticketId, int distance)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPrice(ticketId, distance);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);
            decimal discountedPrice = price.GetType().GetProperty("DiscountedPrice").GetValue(price, null);
            decimal distancePrice = price.GetType().GetProperty("DistancePrice").GetValue(price, null);
            await _consulting.Staff.ApproveConsultingTicket(ticketId, distance, finalPrice, discountedPrice, distancePrice);
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
            }

            string message = createHtmlMessage(ticket.CustomerName, ticket.ConsultingType, ticket.TrainerName, type, ticket.ActualSlotStart, meetLink, (decimal)ticket.Price);
            var mailContent = new MailContent()
            {
                Subject = "Consulting Appointment Information",
                HtmlMessage = message,
            };
            await _mail.SendEmailAsync(ticket.CustomerEmail, mailContent);
        }

        public async Task AssignTrainer(int trainerId, int ticketId, int distance)
        {
            dynamic price = await _transaction.CalculateConsultingTicketFinalPrice(ticketId, distance);
            decimal finalPrice = price.GetType().GetProperty("FinalPrice").GetValue(price, null);
            decimal discountedPrice = price.GetType().GetProperty("DiscountedPrice").GetValue(price, null);
            decimal distancePrice = price.GetType().GetProperty("DistancePrice").GetValue(price, null);
            await _consulting.Staff.AssignTrainer(trainerId, ticketId, distance, finalPrice, discountedPrice, distancePrice);
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
            }
            string message = createHtmlMessage(ticket.CustomerName, ticket.ConsultingType, ticket.TrainerName, type, ticket.ActualSlotStart, meetLink, (decimal)ticket.Price);
            var mailContent = new MailContent()
            {
                Subject = "Consulting Appointment Information",
                HtmlMessage = message,
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
            return await _consulting.Staff.GetListConsultingTicketsByCustomerID(customerID);
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
        public async Task<TicketRatioOnlOff> GetTicketRatioOnlOff(int year)
        {
            return await _consulting.Staff.GetTicketRatioOnlOff(year);
        }
    }
}
