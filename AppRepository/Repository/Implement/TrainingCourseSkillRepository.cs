using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class TrainingCourseSkillRepository : GenericRepository<TrainingCourseSkill>, ITrainingCourseSkillRepository
    {
        public TrainingCourseSkillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
