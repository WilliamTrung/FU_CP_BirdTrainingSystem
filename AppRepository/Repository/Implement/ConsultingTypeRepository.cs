using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class ConsultingTypeRepository : GenericRepository<ConsultingType>, IConsultingTypeRepository
    {
        public ConsultingTypeRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
