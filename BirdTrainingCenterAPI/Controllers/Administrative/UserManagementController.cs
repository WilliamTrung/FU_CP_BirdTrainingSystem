using AppService;
using AppService.AdministrativeService;
using AppService.Implementation;
using BirdTrainingCenterAPI.Controllers.Endpoints.Administrative;
using BirdTrainingCenterAPI.Helper;
using Google.Apis.Storage.v1.Data;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.Extensions.Options;
using Models.ApiParamModels.Administrative;
using Models.ConfigModels;
using Models.ServiceModels.UserModels;
using SP_Middleware;

namespace BirdTrainingCenterAPI.Controllers.Administrative
{
    [Route("api/user-management")]
    [ApiController]
    public class UserManagementController : ODataController, IUserManagement
    {
        private readonly IAdministrativeService _admin;
        private readonly IFirebaseService _firebaseService;
        private readonly FirebaseBucket _bucket;
        public UserManagementController(IAdministrativeService admin, IFirebaseService firebaseService, IOptions<FirebaseBucket> bucket)
        {
            _admin = admin;
            _firebaseService = firebaseService;
            _bucket = bucket.Value;
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
        public async Task<IActionResult> UpdateRecord([FromForm]UserAdminUpdateParamModel model)
        {
            var modelUpdate = model.ToModel();
            await _admin.Administrator.UpdateRecord(modelUpdate);
            if (model.Avatar != null && !model.Avatar.IsImage())
            {
                throw new InvalidOperationException("Uploaded avatar is invalid format!");
            } else if(model.Avatar != null)
            {
                var extension = Path.GetExtension(model.Avatar.FileName);
                var picture = await _firebaseService.UploadFile(model.Avatar, $"{Guid.NewGuid().ToString()}{extension}", FirebaseFolder.PROFILE_USER, _bucket.General);
                var oldPic = await _admin.Profile.UpdateAvatar(model.Id, model.Role, picture);
                await _firebaseService.DeleteFile(oldPic, _bucket.General);
            }
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
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAccount([FromForm]UserAdminAddParamModel model)
        {
            
            var modelAdd = model.ToModel(null);
            var id = await _admin.Administrator.CreateUser(modelAdd);
            string? picture = null;
            if (model.Avatar != null && !model.Avatar.IsImage())
            {
                return BadRequest("Upload image only!");
            }
            else if (model.Avatar != null)
            {
                var extension = Path.GetExtension(model.Avatar.FileName);
                picture = await _firebaseService.UploadFile(model.Avatar, $"{Guid.NewGuid().ToString()}{extension}", FirebaseFolder.PROFILE_USER, _bucket.General);
                await _admin.Profile.UpdateAvatar(id, ((Models.Enum.Role)((int)model.Role)), picture);
            }
            return Ok(id);
        }
        [HttpPost]
        [Route("topup")]
        public async Task<IActionResult> TopupCustomer(int customerId, decimal amount)
        {
            await _admin.Administrator.TopupCustomer(customerId, amount);
            return Ok();
        }
    }
}
