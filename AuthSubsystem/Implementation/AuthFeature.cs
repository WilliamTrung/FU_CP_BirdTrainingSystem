using Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSubsystem.Implementation
{
    public class AuthFeature : IAuthFeature
    {
        public Task Login(LoginModel login_user)
        {
            throw new NotImplementedException();
        }

        public Task Register(RegisterModel register_user)
        {
            throw new NotImplementedException();
        }
    }
}
