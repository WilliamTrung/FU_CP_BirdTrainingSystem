using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureGuest : FeatureUser, IFeatureGuest
    {
        public FeatureGuest(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public Task<IEnumerable<ClassViewModel>> GetClassByWorkshopId(int workshopId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Workshop>> GetWorkshopGeneralInformation()
        {            
            var entities = await _unitOfWork.WorkshopRepository.Get(expression: null, "WorkshopPricePolicy", "WorkshopRefundPolicy");
            var models = _mapper.Map<IEnumerable<Workshop>>(entities);
            return models;
        }
    }
}
