using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class BirdCertificateDetailRepository : GenericRepository<BirdCertificateDetail>, IBirdCertificateDetailRepository
    {
        public BirdCertificateDetailRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
