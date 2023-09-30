using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class SectionRepository : GenericRepository<Section>, ISectionRepository
    {
        public SectionRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
