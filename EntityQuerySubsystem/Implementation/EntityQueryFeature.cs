using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityQuerySubsystem.Implementation
{
    public class EntityQueryFeature : IEntityQueryFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EntityQueryFeature(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<WorkshopClassDetailViewModel> GetWorkshopClassSlotDetail(int entityId)
        { 
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == entityId, nameof(WorkshopClassDetail.DaySlot));
            var model = _mapper.Map<WorkshopClassDetailViewModel>(entity);
            return model;
        }
    }
}
