using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class CustomerWorkshopClassRepository : GenericRepository<CustomerWorkshopClass>, ICustomerWorkshopClassRepository
    {
        public CustomerWorkshopClassRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
