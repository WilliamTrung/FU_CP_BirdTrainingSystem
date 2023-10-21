using AuthSubsystem;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IAuthFeature _authFeature;
        public AuthService(IAuthFeature authFeature)
        {
            _authFeature = authFeature;
        }
        public Task Login(LoginRequestModel login_user) => _authFeature.Login(login_user);

        public Task Register(RegisterRequestModel register_user) => _authFeature.Register(register_user);
    }
}
