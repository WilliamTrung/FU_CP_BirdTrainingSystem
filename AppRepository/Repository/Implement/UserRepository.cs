using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
