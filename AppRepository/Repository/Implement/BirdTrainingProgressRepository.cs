using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingProgressRepository : GenericRepository<BirdTrainingProgress>, IBirdTrainingProgressRepository
    {
        public BirdTrainingProgressRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
