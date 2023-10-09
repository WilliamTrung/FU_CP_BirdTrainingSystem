using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class ConsultingPricePolicyRepository : GenericRepository<ConsultingPricePolicy>, IConsultingPricePolicyRepository
    {
        public ConsultingPricePolicyRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
