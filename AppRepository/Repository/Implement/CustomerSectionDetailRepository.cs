using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class CustomerSectionDetailRepository : GenericRepository<CustomerSectionDetail>, ICustomerSectionDetailRepository
    {
        public CustomerSectionDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
