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
        public override Task Add(BirdTrainingCourse entity)
        {
            entity.LastestUpdate = DateTime.Now;
            return base.Add(entity);
        }
        public override Task Update(BirdTrainingCourse entity)
        {
            entity.LastestUpdate = DateTime.Now;
            return base.Add(entity);
        }
        public override Task Delete(BirdTrainingCourse entity)
        {
            entity.LastestUpdate = DateTime.Now;
            return base.Add(entity);
        }
    }
}
