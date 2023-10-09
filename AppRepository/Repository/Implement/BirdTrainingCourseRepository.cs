using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingCourseRepository : GenericRepository<BirdTrainingCourse>, IBirdTrainingCourseRepository
    {
        public BirdTrainingCourseRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
