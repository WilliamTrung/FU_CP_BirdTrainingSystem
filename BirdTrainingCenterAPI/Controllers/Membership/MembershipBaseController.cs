using AppService;
using AppService.MembershipService;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BirdTrainingCenterAPI.Controllers.Membership
{
    public class MembershipBaseController : ControllerBase
    {
        internal readonly IMembershipService _membershipService;
        internal readonly IAuthService _authService;

        public MembershipBaseController (IMembershipService membershipService, IAuthService authService)
        {
            _membershipService = membershipService;
            _authService = authService;
        }

        internal List<Claim>? DeserializeToken()
        {
            var authHeader = Request.Headers["Authorization"];
            if (authHeader.Count == 0 || !authHeader[0].StartsWith("Bearer "))
            {
                return null;
            }
            string accessToken = authHeader[0].Split(' ')[1];
            return _authService.DeserializedToken(accessToken);
        }
    }
}
