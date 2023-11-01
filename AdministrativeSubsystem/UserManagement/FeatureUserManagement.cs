using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.Enum;
using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativeSubsystem.UserManagement
{
    public class FeatureUserManagement : IFeatureUserManagement
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public FeatureUserManagement(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserAdminViewModel>> GetUsersInformation()
        {
            var entities = await _uow.UserRepository.Get(null, nameof(User.Customers), nameof(User.Trainers));
            var models = _mapper.Map<List<UserAdminViewModel>>(entities);
            return models;
        }

        public Task UpdateRecord(UserAdminUpdateModel user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRole(UserRoleUpdateModel model)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Role> GetRoles()
        {
            var roles = Enum.GetValues(typeof(Role)).Cast<Role>();
            return roles;
        }

    }
}
