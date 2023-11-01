using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdministrativeService
{
    public interface IAdministrativeService
    {
        IServiceAdministrator Administrator { get; }        
    }
    public class AdministrativeService : IAdministrativeService
    {
        public IServiceAdministrator Administrator { get; }
        public AdministrativeService(IServiceAdministrator serviceAdministrator)
        {
            Administrator = serviceAdministrator;
        }

    }
}
