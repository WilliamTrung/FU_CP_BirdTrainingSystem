﻿using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem.Implementation
{
    public class FeatureAll : IFeatureAll
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureAll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<WorkshopClassViewModel>> GetClassesByWorkshopId(int workshopId)
        {
            var entities = await _unitOfWork.WorkshopClassRepository.Get(c => c.WorkshopId == workshopId, nameof(WorkshopClass.WorkshopClassDetails));
            var models = _mapper.Map<List<WorkshopClassViewModel>>(entities);
            return models;
        }

        public async Task<WorkshopClassDetailViewModel> GetWorkshopClassDetail(int workshopClassDetailId)
        {
            var entity = await _unitOfWork.WorkshopClassDetailRepository.GetFirst(c => c.Id == workshopClassDetailId, nameof(WorkshopClassDetail.DaySlot));
            var model = _mapper.Map<WorkshopClassDetailViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<WorkshopClassDetailViewModel>> GetWorkshopClassDetailOnWorkshopClass(int workshopClassId)
        {
            var entities = await _unitOfWork.WorkshopClassDetailRepository.Get(c => c.WorkshopClassId == workshopClassId, nameof(WorkshopClassDetail.DaySlot));
            var models = _mapper.Map<List<WorkshopClassDetailViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<WorkshopModel>> GetWorkshopGeneralInformation()
        {            
            var entities = await _unitOfWork.WorkshopRepository.Get(expression: null, nameof(Workshop.WorkshopRefundPolicy));
            var models = _mapper.Map<IEnumerable<WorkshopModel>>(entities);
            return models;
        }
    }
}