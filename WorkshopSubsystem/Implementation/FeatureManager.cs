using AppCore.Context;
using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopRefundPolicy;
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
            if (workshop.MinimumRegistration > workshop.MaximumRegistration)
            {
                throw new InvalidDataException("Minimum registration must be smaller than maximum registration");
            }
            else if (workshop.MinimumRegistration < 1 || workshop.MaximumRegistration < 1 || workshop.RegisterEnd < 1 || workshop.Price < 1 || workshop.TotalSlot < 1)
            {
                throw new InvalidDataException("Value must be positive number");
            }
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

        public async Task ModifyWorkshop(WorkshopModifyModel workshop)
        {
            var entity = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshop.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Workshop not found for id: " + workshop.Id);
            }
            if (workshop.RegisterEnd != null)
            {
                entity.RegisterEnd = workshop.RegisterEnd;
            }
            if (workshop.MinimumRegistration != null)
            {
                entity.MinimumRegistration = (int)workshop.MinimumRegistration;
            }
            if (workshop.MaximumRegistration != null)
            {
                entity.MaximumRegistration = (int)workshop.MaximumRegistration;
            }
            if (workshop.Picture != null)
            {
                entity.Picture = workshop.Picture;
            }
            if (workshop.Price != null)
            {
                entity.Price = (decimal)workshop.Price;
            }
            if (workshop.Description != null)
            {
                entity.Description = workshop.Description;
            }
            if (workshop.Title != null)
            {
                entity.Title = workshop.Title;
            }
            //if (workshop.TotalSlot != null)
            //{
            //    entity.TotalSlot = (int)workshop.TotalSlot;
            //}
            //if (workshop.Location != null)
            //{
            //    entity.Location = workshop.Location;
            //}
            await _unitOfWork.WorkshopRepository.Update(entity);
        }

        public async Task ModifyWorkshopDetailTemplate(WorkshopDetailTemplateModiyModel workshopDetail)
        {
            var entity = await _unitOfWork.WorkshopDetailTemplateRepository.GetFirst(c => c.Id == workshopDetail.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException(nameof(workshopDetail));
            }
            entity.Detail = workshopDetail.Detail;
            await _unitOfWork.WorkshopDetailTemplateRepository.Update(entity);


        }

        public async Task ModifyWorkshopStatus(WorkshopStatusModifyModel workshop)
        {
            var entity = await _unitOfWork.WorkshopRepository.GetFirst(c => c.Id == workshop.Id);
            if (entity == null)
            {
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
            }
            else if (details.All(c => c.Detail != string.Empty) && workshop.Status == (int)Models.Enum.Workshop.Status.Active)
            {
                //set workshop status to active
                entity.Status = workshop.Status;
                await _unitOfWork.WorkshopRepository.Update(entity);
            }
            else
            {
                throw new InvalidOperationException("Detail templates are not fulfilled!");
            }
        }

        public async Task CreateRefundPolicy(WorkshopRefundPolicyAddModel addModel)
        {
            if (addModel.TotalDayBeforeStart < 0)
            {
                throw new InvalidDataException("Total date before start must be positive");
            }
            if (addModel.RefundRate < 0 || addModel.RefundRate == null)
            {
                throw new InvalidDataException("Refund Rate must be positive");
            }
            var entity = _mapper.Map<WorkshopRefundPolicy>(addModel);
            await _unitOfWork.WorkshopRefundPolicyRepository.Add(entity);
        }

        public async Task EditRefundPolicy(WorkshopRefundPolicyViewModModel modModel)
        {
            if (modModel.TotalDayBeforeStart < 0)
            {
                throw new InvalidDataException("Total date before start must be positive");
            }
            if (modModel.RefundRate < 0 || modModel.RefundRate == null)
            {
                throw new InvalidDataException("Refund Rate must be positive");
            }
            var entity = await _unitOfWork.WorkshopRefundPolicyRepository.GetFirst(e => e.Id == modModel.Id);
            if (entity == null)
            {
                throw new KeyNotFoundException($"{typeof(WorkshopRefundPolicy)} is not found at id: {modModel.Id}");
            }
            if (modModel.TotalDayBeforeStart >= 0)
            {
                entity.TotalDayBeforeStart = modModel.TotalDayBeforeStart;
            }
            if (modModel.RefundRate >= 0 && modModel.RefundRate != null)
            {
                entity.RefundRate = modModel.RefundRate;
            }
            await _unitOfWork.WorkshopRefundPolicyRepository.Update(entity);
        }
    }
}
