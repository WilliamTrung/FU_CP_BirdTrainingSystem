using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureTrainer : FeatureAll, IFeatureTrainer
    {
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task ModifyWorkshopClassSlotDetail(WorkshopClassDetailModifyModel workshopClass)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClass.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{nameof(workshopClass)} is not found at id: {workshopClass.Id}");
            }
            entity.Detail = workshopClass.Detail;
            await _unitOfWork.WorkshopClassDetailRepository.Update(entity);
        }
    }
}
