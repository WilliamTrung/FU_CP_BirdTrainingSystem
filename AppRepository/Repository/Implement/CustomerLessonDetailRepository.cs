using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class CustomerLessonDetailRepository : GenericRepository<CustomerLessonDetail>, ICustomerLessonDetailRepository
    {
        public CustomerLessonDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
