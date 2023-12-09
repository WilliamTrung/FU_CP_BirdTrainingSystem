using AppService.AdministrativeService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Administrative;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Models.ServiceModels.UserModels;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.Administrative
{
    [Route("api/user-management")]
    [ApiController]
    public class UserManagementController : ODataController, IUserManagement
    {
        private readonly IAdministrativeService _admin;
        public UserManagementController(IAdministrativeService admin)
        {
            _admin = admin;
        }
        [HttpGet]
        [EnableQuery]
        [Route("users")]
        [CustomAuthorize(roles: "Administrator")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _admin.Administrator.GetUsersInformation();
            return Ok(result);
        }
        [HttpGet]
        [EnableQuery]
        [Route("trainers")]
        [CustomAuthorize(roles: "Manager,Staff,Trainer")]
        public async Task<IActionResult> GetTrainers()
        {
            var result = await _admin.Administrator.GetTrainersInformation();
            return Ok(result);
        }
        [HttpGet]
        [Route("roles")]
        [CustomAuthorize(roles: "Administrator")]
        public IActionResult GetRoles()
        {
            var result = _admin.Administrator.GetRoles();
            return Ok(result);
        }
        [HttpPut]
        [Route("update-role")]
        [CustomAuthorize(roles: "Administrator")]
        public async Task<IActionResult> UpdateRole(UserRoleUpdateModel model)
        {
            await _admin.Administrator.UpdateRole(model);
            return Ok();
        }
        [HttpPut]
        [Route("update")]
        [CustomAuthorize(roles: "Administrator")]
        public async Task<IActionResult> UpdateRecord(UserAdminUpdateModel model)
        {
            await _admin.Administrator.UpdateRecord(model);
            return Ok();
        }
        [HttpGet]
        [Route("customer-statuses")]
        [CustomAuthorize(roles: "Administrator")]
        public IActionResult GetUserStatuses()
        {
            var result = _admin.Administrator.GetCustomerStatuses();
            return Ok(result);
        }
        [HttpGet]
        [Route("trainer-statuses")]
        [CustomAuthorize(roles: "Administrator")]
        public IActionResult GetTrainerStatuses()
        {
            var result = _admin.Administrator.GetTrainerStatuses();
            return Ok(result);
        }
        [HttpPut]
        [Route("update-status")]
        [CustomAuthorize(roles: "Administrator")]
        public async Task<IActionResult> UpdateStatus(UserStatusUpdateModel model)
        {
            await _admin.Administrator.UpdateStatus(model);
            return Ok();
        }
    }
}
