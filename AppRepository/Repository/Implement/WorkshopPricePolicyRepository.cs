using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class WorkshopPricePolicyRepository : GenericRepository<WorkshopPricePolicy>, IWorkshopPricePolicyRepository
    {
        public WorkshopPricePolicyRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
