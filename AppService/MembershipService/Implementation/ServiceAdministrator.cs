using MembershipSubSystem;
using Models.ServiceModels.MembershipModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.MembershipService.Implementation
{
    public class ServiceAdministrator : IServiceAdministrator
    {
        IMembershipFeature _membership;
        public ServiceAdministrator(IMembershipFeature membership) 
        {
            _membership = membership;
        }
        public async Task CreateMembershipRank(MembershipCreateNewServiceModel membership)
        {
            await _membership.Admin.CreateMembershipRank(membership);
        }

        public async Task DeleteMembershipRank(int id)
        {
            await _membership.Admin.DeleteMembershipRank(id);
        }

        public async Task<IEnumerable<MembershipServiceModel>> GetListMembershipRank()
        {
            var listMembership = await _membership.Admin.GetListMembershipRank();
            return listMembership;
        }

        public async Task<MembershipServiceModel> GetMembershipRankDetail(int id)
        {
            var membership = await _membership.Admin.GetMembershipRankDetail(id);
            return membership;
        }

        public async Task UpdateMembershipRank(MembershipUpdateServiceModel membership)
        {
            await _membership?.Admin.UpdateMembershipRank(membership);
        }
    }
}
