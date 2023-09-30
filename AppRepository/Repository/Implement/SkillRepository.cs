using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
