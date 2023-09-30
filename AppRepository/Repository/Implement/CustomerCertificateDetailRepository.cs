using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class CustomerCertificateDetailRepository : GenericRepository<CustomerCertificateDetail>, ICustomerCertificateDetailRepository
    {
        public CustomerCertificateDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
