using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class CustomerCertificateDetailRepository : GenericRepository<CustomerCertificateDetail>, ICustomerCertificateDetailRepository
    {
        public CustomerCertificateDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
