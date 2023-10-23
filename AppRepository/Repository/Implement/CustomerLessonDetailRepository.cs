using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class CustomerLessonDetailRepository : GenericRepository<CustomerLessonDetail>, ICustomerLessonDetailRepository
    {
        public CustomerLessonDetailRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
