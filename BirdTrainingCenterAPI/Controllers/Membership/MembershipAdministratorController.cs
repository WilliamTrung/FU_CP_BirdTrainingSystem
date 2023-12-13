using AppService;
using AppService.MembershipService;
using BirdTrainingCenterAPI.Controllers.Endpoints.Membership;
using BirdTrainingCenterAPI.Helper;
using Microsoft.AspNetCore.Mvc;
using Models.ServiceModels.MembershipModels;

namespace BirdTrainingCenterAPI.Controllers.Membership
{
    public class MembershipAdministratorController : MembershipBaseController, IMembershipAdministrator
    {
        public MembershipAdministratorController(IMembershipService membershipService, IAuthService authService) : base(membershipService, authService) 
        {

        }

        [HttpPost]
        [Route("createNewMembership")]
        public async Task<IActionResult> CreateNewMembership(MembershipCreateNewServiceModel membership)
        {
            //AccessToken
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }

            if (membership.Discount <= 0 || membership.Requirement <= 0)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, "Discount or Requirement must greater than 0");
            }
            await _membershipService.Admin.CreateMembershipRank(membership);
            return Ok();
        }

        [HttpDelete]
        [Route("deleteMembership")]
        public async Task<IActionResult> DeleteMembership(int id)
        {
            //AccessToken
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }

            await _membershipService.Admin.DeleteMembershipRank(id);
            return Ok();
        }

        [HttpGet]
        [Route("getListMembership")]
        public async Task<IActionResult> GetListMembership()
        {
            var result = await _membershipService.Admin.GetListMembershipRank();
            return Ok(result);
        }

        [HttpGet]
        [Route("getMembershipDetail")]
        public async Task<IActionResult> GetMembershipDetail(int id)
        {
            var result = await _membershipService.Admin.GetMembershipRankDetail(id);
            return Ok(result);
        }

        [HttpPut]
        [Route("updateMembership")]
        public async Task<IActionResult> UpdateMembership(MembershipUpdateServiceModel membership)
        {
            //AccessToken
            var accessToken = Request.DeserializeToken(_authService);
            if (accessToken == null)
            {
                return Unauthorized();
            }

            await _membershipService.Admin.UpdateMembershipRank(membership);
            return Ok();
        }
    }
}
