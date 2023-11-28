using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class CustomerCertificateDetailRepository : GenericRepository<CustomerCertificateDetail>, ICustomerCertificateDetailRepository
    {
        public CustomerCertificateDetailRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public override Task Update(CustomerCertificateDetail entity)
        {
            entity.ReceiveDate = DateTime.UtcNow.AddHours(7);
            return base.Update(entity);
        }
    }
}
