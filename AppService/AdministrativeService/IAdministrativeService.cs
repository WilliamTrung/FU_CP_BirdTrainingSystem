using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdministrativeService
{
    public interface IAdministrativeService
    {
        IServiceProfile Profile { get; }
        IServiceAdministrator Administrator { get; }        
    }
    public class AdministrativeService : IAdministrativeService
    {
        public IServiceAdministrator Administrator { get; }
        public IServiceProfile Profile { get; }
        public AdministrativeService(IServiceAdministrator serviceAdministrator, IServiceProfile profile)
        {
            Administrator = serviceAdministrator;
            Profile = profile;
        }

    }
}
