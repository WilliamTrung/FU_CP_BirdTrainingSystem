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
    [CustomAuthorize(roles: "Administrator")]
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
        public async Task<IActionResult> GetUsers()
        {            
            try
            {
                var result = await _admin.Administrator.GetUsersInformation();
                return Ok(result);
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("roles")]
        public IActionResult GetRoles()
        {
            var result = _admin.Administrator.GetRoles();
            return Ok(result);
        }
        [HttpPut]
        [Route("update-role")]
        public async Task<IActionResult> UpdateRole(UserRoleUpdateModel model)
        {
            try
            {
                await _admin.Administrator.UpdateRole(model);
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateRecord(UserAdminUpdateModel model)
        {
            try
            {
                await _admin.Administrator.UpdateRecord(model);
                return Ok();
            } catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
        [HttpGet]
        [Route("customer-statuses")]
        public IActionResult GetUserStatuses()
        {
            var result = _admin.Administrator.GetCustomerStatuses();
            return Ok(result);
        }
        [HttpGet]
        [Route("trainer-statuses")]
        public IActionResult GetTrainerStatuses()
        {
            var result = _admin.Administrator.GetTrainerStatuses();
            return Ok(result);
        }
        [HttpPut]
        [Route("update-status")]
        public async Task<IActionResult> UpdateStatus(UserStatusUpdateModel model)
        {
            try
            {
                await _admin.Administrator.UpdateStatus(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
