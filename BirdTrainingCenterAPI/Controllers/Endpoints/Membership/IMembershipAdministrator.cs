using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.MembershipModels;

namespace BirdTrainingCenterAPI.Controllers.Endpoints.Membership
{
    public interface IMembershipAdministrator
    {
        [HttpPost]
        [Route("createNewMembership")]
        Task<IActionResult> CreateNewMembership(MembershipCreateNewServiceModel membership);

        [HttpGet]
        [Route("getListMembership")]
        Task<IActionResult> GetListMembership();

        [HttpGet]
        [Route("getMembershipDetail")]
        Task<IActionResult> GetMembershipDetail(int id);

        [HttpPut]
        [Route("updateMembership")]
        Task<IActionResult> UpdateMembership(MembershipUpdateServiceModel membership);

        [HttpDelete]
        [Route("deleteMembership")]
        Task<IActionResult> DeleteMembership(int id);
    }
}
