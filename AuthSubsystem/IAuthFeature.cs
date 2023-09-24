using Models.AuthModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthSubsystem
{
    public interface IAuthFeature
    {
        Task Login(LoginModel login_user);
        Task Register(RegisterModel register_user);
    }
}
