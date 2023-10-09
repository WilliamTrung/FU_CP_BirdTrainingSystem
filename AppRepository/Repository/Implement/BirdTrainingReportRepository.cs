using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingReportRepository : GenericRepository<BirdTrainingReport>, IBirdTrainingReportRepository
    {
        public BirdTrainingReportRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
