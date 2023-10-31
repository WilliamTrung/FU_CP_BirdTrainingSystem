using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
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

        public async Task<int> CreateWorkshop(WorkshopAddModel workshop)
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
            return entity.Id;
        }

        public async Task<IEnumerable<WorkshopDetailTemplateViewModel>> GetDetailTemplatesByWorkshopId(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopDetailTemplateRepository.Get(c => c.WorkshopId == workshopId);
            var models = _mapper.Map<List<WorkshopDetailTemplateViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopAdminModel>> GetWorkshops()
        {
            var entities = await _unitOfWork.WorkshopRepository.Get();
            var models = _mapper.Map<IEnumerable<WorkshopAdminModel>>(entities);
            return models;
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
            //entity.Status = workshop.Status;
            var details = await _unitOfWork.WorkshopDetailTemplateRepository.Get(c => c.WorkshopId == workshop.Id);
            if (workshop.Status == (int)Models.Enum.Workshop.Status.Inactive)
            {
                //26-10-2023 - TrungNT - Delete Start
                ////check if any class is in progress or registration
                //var classes = await _unitOfWork.WorkshopClassRepository.Get(c => c.Status == (int)Models.Enum.Workshop.Class.Status.OpenRegistration 
                //                                                                || c.Status == (int)Models.Enum.Workshop.Class.Status.OnGoing);
                //if (classes.Any())
                //{
                //    throw new InvalidOperationException("Classes are in operation!");
                //}
                //26-10-2023 - TrungNT - Delete End
                entity.Status = workshop.Status;
                await _unitOfWork.WorkshopRepository.Update(entity);
            } else if (details.All(c => c.Detail != string.Empty) && workshop.Status == (int)Models.Enum.Workshop.Status.Active)
            {
                //set workshop status to active
                entity.Status = workshop.Status;
                await _unitOfWork.WorkshopRepository.Update(entity);
            } else
            {
                throw new InvalidOperationException("Detail templates are not fulfilled!");
            }
        }
    }
}
