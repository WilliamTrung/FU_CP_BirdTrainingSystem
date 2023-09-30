using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingProgressRepository : GenericRepository<BirdTrainingProgress>, IBirdTrainingProgressRepository
    {
        public BirdTrainingProgressRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
