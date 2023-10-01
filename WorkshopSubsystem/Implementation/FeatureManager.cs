using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.WorkshopModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureManager : FeatureStaff, IFeatureManager
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Task AddWorkshop(Workshop workshop)
        {
            throw new NotImplementedException();
        }

        public Task ChangeWorkshopStatus(int workshopId)
        {
            throw new NotImplementedException();
        }

        public Task EditWorkshop(Workshop workshop)
        {
            throw new NotImplementedException();
        }
    }
}
