using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class WorkshopClassDetailRepository : GenericRepository<WorkshopClassDetail>, IWorkshopClassDetailRepository
    {
        public WorkshopClassDetailRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public override Task Add(WorkshopClassDetail entity)
        {
            entity.UpdateDate = DateTime.Now;
            return base.Add(entity);
        }
        public override Task Update(WorkshopClassDetail entity)
        {
            entity.UpdateDate = DateTime.Now;
            return base.Update(entity);
        }
    }
}
