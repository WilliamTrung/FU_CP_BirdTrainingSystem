using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class WorkshopClassRepository : GenericRepository<WorkshopClass>, IWorkshopClassRepository
    {
        public WorkshopClassRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public override Task Add(WorkshopClass entity)
        {
            entity.CreateDate = DateTime.Now;
            return base.Add(entity);
        }
    }
}
