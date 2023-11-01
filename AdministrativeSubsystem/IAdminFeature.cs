using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeSubsystem
{
    public interface IAdminFeature
    {
        IFeatureProfileManagement Profile { get; }
        IFeatureUserManagement User { get; }
    }
    public class AdminFeature : IAdminFeature
    {
        public IFeatureProfileManagement Profile { get; }
        public IFeatureUserManagement User { get; }
        public AdminFeature(IFeatureUserManagement _userManagement, IFeatureProfileManagement _profileManagement)
        {
            User = _userManagement;
            Profile = _profileManagement;
        }
    }
}
