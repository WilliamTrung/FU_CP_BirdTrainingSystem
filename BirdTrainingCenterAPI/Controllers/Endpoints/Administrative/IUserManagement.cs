using Microsoft.AspNetCore.Mvc;
using Models.ApiParamModels.Administrative;
using Models.ServiceModels.UserModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Administrative
{
    public interface IUserManagement
    {
        [HttpGet]
        [Route("/users")]
        Task<IActionResult> GetUsers();
        [HttpGet]
        [Route("roles")]
        IActionResult GetRoles();
        [HttpGet]
        [Route("user-statuses")]
        IActionResult GetUserStatuses();
        [HttpGet]
        [Route("trainer-statuses")]
        IActionResult GetTrainerStatuses();
        [HttpPut]
        [Route("/update-role")]
        Task<IActionResult> UpdateRole(UserRoleUpdateModel model);
        [HttpPut]
        [Route("update-status")]
        Task<IActionResult> UpdateStatus(UserStatusUpdateModel model);
        [HttpPut]
        [Route("/update")]
        Task<IActionResult> UpdateRecord(UserAdminUpdateParamModel model);
        [HttpPost]
        [Route("/create")]
        Task<IActionResult> CreateAccount(UserAdminAddParamModel model);
        [HttpPost]
        [Route("/topup")]
        Task<IActionResult> TopupCustomer(int customerId, decimal amount);
    }
}
