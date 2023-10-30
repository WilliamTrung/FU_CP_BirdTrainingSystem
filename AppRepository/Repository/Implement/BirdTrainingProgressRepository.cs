using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;
using System.Linq.Expressions;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingProgressRepository : GenericRepository<BirdTrainingProgress>, IBirdTrainingProgressRepository
    {
        public BirdTrainingProgressRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public override async Task<IEnumerable<BirdTrainingProgress>> Get(Expression<Func<BirdTrainingProgress, bool>>? expression = null, params string[] includeProperties)
        {
            var entities = await base.Get(expression, includeProperties);
            foreach (var entity in entities)
            {
                if (entity != null)
                {
                    int compareDate = DateTime.Compare((DateTime)entity.StartTrainingDate, DateTime.Now);
                    if (entity.Status == (int)Models.Enum.BirdTrainingProgress.Status.Assigned && compareDate >= 0)
                    {
                        entity.Status = (int)Models.Enum.BirdTrainingProgress.Status.Training;
                        await Update(entity);
                    }
                }
            }
            return entities;
        }
    }
}
