using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingReportRepository : GenericRepository<BirdTrainingReport>, IBirdTrainingReportRepository
    {
        public BirdTrainingReportRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
