using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;
using System.Linq.Expressions;

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
        public override async Task<IEnumerable<BirdTrainingCourse>> Get(Expression<Func<BirdTrainingCourse, bool>>? expression = null, params string[] includeProperties)
        {
            var entities = await base.Get(expression, includeProperties);
            foreach (var entity in entities)
            {
                if(entity != null)
                {
                    int compareDate = DateTime.Compare((DateTime)entity.ActualStartDate, DateTime.Now);
                    if(entity.Status == (int)Models.Enum.BirdTrainingCourse.Status.ReceivedBirdFromCustomer && compareDate >= 0)
                    {
                        entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Training;
                        await Update(entity);
                    }
                    else if(entity.Status == (int)Models.Enum.BirdTrainingCourse.Status.AssignedTrainerToCourse && compareDate > 0)
                    {
                        entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Registered;
                        await Update(entity);
                    }
                }
            }
            var result = await base.Get(expression, includeProperties);
            return result;
        }
    }
}
