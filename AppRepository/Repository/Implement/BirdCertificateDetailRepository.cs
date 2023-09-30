using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class BirdCertificateDetailRepository : GenericRepository<BirdCertificateDetail>, IBirdCertificateDetailRepository
    {
        public BirdCertificateDetailRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
