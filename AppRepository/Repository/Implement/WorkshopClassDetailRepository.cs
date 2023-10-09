using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class WorkshopClassDetailRepository : GenericRepository<WorkshopClassDetail>, IWorkshopClassDetailRepository
    {
        public WorkshopClassDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
