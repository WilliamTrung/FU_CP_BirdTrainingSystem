using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
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

        public async Task CreateWorkshop(WorkshopAddModel workshop)
        {
            var entity = _mapper.Map<Workshop>(workshop);
            await _unitOfWork.WorkshopRepository.Add(entity);
            //add workshop class details to class
            for (var i = 0; i < entity.TotalSlot; i++)
            {
                var detailTemplate = new WorkshopDetailTemplateAddModel(entity.Id);
                var enttiy_detailTemplate = _mapper.Map<WorkshopDetailTemplate>(detailTemplate);
                await _unitOfWork.WorkshopDetailTemplateRepository.Add(enttiy_detailTemplate);
            }
        }

       

        //public async Task ModifyWorkshop(WorkshopModifyModel workshop)
        //{
        //    var entity = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshop.Id);
        //    if(entity == null)
        //    {
        //        throw new KeyNotFoundException($"{typeof(Workshop)} is not found at id: {workshop.Id}");
        //    }
        //    if(workshop.Title != null)
        //    {
        //        entity.Title = workshop.Title;
        //    }
        //    if(workshop.Description != null)
        //    {
        //        entity.Description = workshop.Description;
        //    }
        //    if (workshop.Picture != null)
        //    {
        //        entity.Picture = workshop.Picture;
        //    }
        //    if (workshop.RegisterEnd != null)
        //    {
        //        entity.RegisterEnd = workshop.RegisterEnd;
        //    }
        //    if (workshop.Price != null)
        //    {
        //        entity.Price = workshop.Price.Value;
        //    }
        //    if (workshop.TotalSlot != null)
        //    {
        //        entity.RegisterEnd = workshop.TotalSlot;
        //    }
        //    await _unitOfWork.WorkshopRepository.Update(entity);
        //}

        public async Task ModifyWorkshopDetailTemplate(WorkshopDetailTemplateModiyModel workshopDetail)
        {
            var entity = await _unitOfWork.WorkshopDetailTemplateRepository.GetFirst(c => c.Id == workshopDetail.Id);
            if(entity == null)
            {
                throw new KeyNotFoundException(nameof(workshopDetail));
            }
            entity.Detail = workshopDetail.Detail;
            await _unitOfWork.WorkshopDetailTemplateRepository.Update(entity);
        }

        public async Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop)
        {
            var entity = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshop.Id);
            if(entity == null) {
                throw new KeyNotFoundException($"{typeof(Workshop)} is not found at id: {workshop.Id}");
            }
            entity.Status = workshop.Status;
        }
    }
}
