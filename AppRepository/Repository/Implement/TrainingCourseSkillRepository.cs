using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class TrainingCourseSkillRepository : GenericRepository<TrainingCourseSkill>, ITrainingCourseSkillRepository
    {
        public TrainingCourseSkillRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
