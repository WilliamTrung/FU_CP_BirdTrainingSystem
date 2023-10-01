using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class CustomerOnlineCourseDetailRepository : GenericRepository<CustomerOnlineCourseDetail>, ICustomerOnlineCourseDetailRepository
    {
        public CustomerOnlineCourseDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
