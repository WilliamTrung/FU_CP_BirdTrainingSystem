using Models.ServiceModels.MembershipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.MembershipService
{
    public interface IServiceAdministrator
    {
        Task CreateMembershipRank(MembershipCreateNewServiceModel membership);
        Task<IEnumerable<MembershipServiceModel>> GetListMembershipRank();
        Task<MembershipServiceModel> GetMembershipRankDetail(int id);
        Task UpdateMembershipRank(MembershipUpdateServiceModel membership);
        Task DeleteMembershipRank(int id);
    }
}
