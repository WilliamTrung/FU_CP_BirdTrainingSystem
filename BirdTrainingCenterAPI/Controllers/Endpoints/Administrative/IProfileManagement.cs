using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.UserModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Administrative
{
    public interface IProfileManagement
    {
        [HttpGet]
        Task<IActionResult> GetProfile();
        [HttpPut]
        [Route("update-information")]
        Task<IActionResult> UpdateInformation(AdditionalUpdateModel model);
        [HttpPut]
        [Route("update-avatar")]
        Task<IActionResult> UpdateAvatar(IFormFile avatar);
    }
}
