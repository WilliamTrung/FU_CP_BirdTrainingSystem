using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.MembershipService
{
    public interface IMembershipService
    {
        IServiceAdministrator Admin { get; }

        public class MembershipService : IMembershipService
        {
            private readonly IServiceAdministrator _admin;
            public MembershipService (IServiceAdministrator admin)
            {
                _admin = admin;
            }

            public IServiceAdministrator Admin => _admin;
        }
    }
}
