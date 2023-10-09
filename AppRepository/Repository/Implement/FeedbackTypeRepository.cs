using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class FeedbackTypeRepository : GenericRepository<FeedbackType>, IFeedbackTypeRepository
    {
        public FeedbackTypeRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
