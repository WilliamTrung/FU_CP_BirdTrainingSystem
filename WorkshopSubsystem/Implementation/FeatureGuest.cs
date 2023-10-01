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
    public class FeatureGuest : IFeatureGuest
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FeatureGuest(IUnitOfWork unitOfWork, IMapper mapper) { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Workshop>> GetWorkshopGeneralInformation()
        {            
            var entities = await _unitOfWork.WorkshopRepository.Get(expression: null, "WorkshopPricePolicy", "WorkshopRefundPolicy");
            var models = _mapper.Map<IEnumerable<Workshop>>(entities);
            return models;
        }
    }
}
