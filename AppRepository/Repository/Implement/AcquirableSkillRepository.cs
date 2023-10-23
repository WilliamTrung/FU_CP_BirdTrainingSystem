using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class AcquirableSkillRepository : GenericRepository<AcquirableSkill>, IAcquirableSkillRepository
    {
        public AcquirableSkillRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
