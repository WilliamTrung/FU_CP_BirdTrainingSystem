using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class AdditionalConsultingBillRepository : GenericRepository<AdditionalConsultingBill>, IAdditionalConsultingBillRepository
    {
        public AdditionalConsultingBillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
