using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.AdviceConsulting;
using Models.ServiceModels.AdviceConsultantModels;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using System.ComponentModel;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.AdviceConsulting
{
    public interface IAdviceConsultingCustomer
    {
        [HttpPost]
        [Route("sendConsultingTicket")]
        Task<IActionResult> SendConsultingTicket(ConsultingTicketCreateNewParamModel paramTicket);

        [HttpGet]
        [Route("listCustomerConsultingTicket")]
        Task<IActionResult> GetListConsultingTicketByCustomerId(int customerId);

        [HttpGet]
        [Route("validateBeforeUsingSendConsultingTicket")]
        Task<IActionResult> ValidateBeforeUsingSendConsultingTicket(int customerId);

        [HttpGet]
        [Route("getListAddress")]
        Task<IActionResult> GetListAddress();

        [HttpPost]
        [Route("createNewAddress")]
        Task<IActionResult> CreateNewAddress(AddressCreateNewParamModel paramAddress);

    }
}
