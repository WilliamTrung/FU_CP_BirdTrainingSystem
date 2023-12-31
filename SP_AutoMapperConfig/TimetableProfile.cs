﻿using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TimetableProfile : Profile
    {
        public TimetableProfile() {
            Map_Slot_SlotModel();
            Map_TrainerSlot_SlotModel();
            Map_TrainerSlot_TrainerSlotModel();
            Map_TrainerSlot_TrainerSlotDetailModel();
            Map_TrainerSlot_TimetableModel();
            Map_Trainer_TrainerModel();
            Map_AbsentInDayModel_TrainerSlot();
            Map_AbsentDayRangeModel_ListAbsentInDayModel();
        }
        private void Map_AbsentDayRangeModel_ListAbsentInDayModel()
        {
            CreateMap<AbsentDateRangeModel, List<AbsentInDayModel>>()
                .AfterMap<MappingAction_AbsentDateRange_ListAbsentInDayModel_TrainerSlot>();
        }
        private void Map_AbsentInDayModel_TrainerSlot()
        {
            CreateMap<AbsentInDayModel, TrainerSlot>()
                .AfterMap<MappingAction_AbsentInDayModel_TrainerSlot>();
        }
        private void Map_Trainer_TrainerModel()
        {
            
            CreateMap<Trainer, TrainerModel>()
                .AfterMap<MappingAction_Trainer_TrainerModel>();
        }
        private void Map_TrainerSlot_TrainerSlotDetailModel()
        {
            CreateMap<TrainerSlot, TrainerSlotDetailModel>()
                .ForMember(m => m.StartTime, opt =>
                {
                    opt.PreCondition(e => e.Slot != null);
                    opt.MapFrom(e => e.Slot.StartTime);
                })
                .ForMember(m => m.EndTime, opt =>
                {
                    opt.PreCondition(e => e.Slot != null);
                    opt.MapFrom(e => e.Slot.EndTime);
                });
        }
        private void Map_TrainerSlot_TimetableModel()
        {
            CreateMap<TrainerSlot, TimetableModel>()
                .AfterMap<MappingAction_TrainerSlot_TimetableModel>();
                //.ForMember(m => m.Id, opt =>
                //{
                //    opt.MapFrom(e => e.Id);
                //})
                //.ForMember(m => m.SlotId, opt =>
                //{
                //    opt.MapFrom(e => e.SlotId);
                //})
                //.ForMember(m => m.Date, opt =>
                //{
                //    opt.MapFrom(e => e.Date.ToDateOnly());
                //})
                //.ForMember(m => m.Reason, opt =>
                //{
                //    opt.MapFrom(e => e.Reason);
                //})
                //.ForMember(m => m.TypeId, opt =>
                //{
                //    opt.MapFrom(e => e.EntityTypeId);
                //})
                //.ForMember(m => m.TypeName, opt =>
                //{
                //    opt.MapFrom(e => e.EntityTypeId);
                //})
                //.ForMember(m => m.StartTime, opt =>
                //{
                //    opt.PreCondition(e => e.Slot != null);
                //    opt.MapFrom(e => e.Date + e.Slot.StartTime);
                //})
                //.ForMember(m => m.EndTime, opt =>
                //{
                //    opt.PreCondition(e => e.Slot != null);
                //    opt.MapFrom(e => e.Date + e.Slot.EndTime);
                //});
        }
        private void Map_Slot_SlotModel()
        {
            CreateMap<Slot,SlotModel>();
        }
        private void Map_TrainerSlot_SlotModel()
        {
            CreateMap<TrainerSlot, SlotModel>()
                //.ForMember(m => m, opt =>
                //{
                //    opt.PreCondition(e => e.Slot != null);
                //    opt.MapFrom(e => e.Slot);
                //});
                .AfterMap<MappingAction_TrainerSlot_SlotModel>();
        }
        private void Map_TrainerSlot_TrainerSlotModel()
        {
            CreateMap<TrainerSlot, TrainerSlotModel>()
                .ForMember(m => m.StartTime, opt =>
                {
                    opt.PreCondition(e => e.Slot != null);
                    opt.MapFrom(e => e.Slot.StartTime);
                })
                .ForMember(m => m.EndTime, opt =>
                {
                    opt.PreCondition(e => e.Slot != null);
                    opt.MapFrom(e => e.Slot.EndTime);
                });
        }
    }
    public class MappingAction_TrainerSlot_SlotModel : IMappingAction<TrainerSlot, SlotModel>
    {
        private readonly IMapper _mapper;
        public MappingAction_TrainerSlot_SlotModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Process(TrainerSlot source, SlotModel destination, ResolutionContext context)
        {
            destination = _mapper.Map<SlotModel>(source.Slot);
        }
    }
    public class MappingAction_AbsentDateRange_ListAbsentInDayModel_TrainerSlot : IMappingAction<AbsentDateRangeModel, List<AbsentInDayModel>>
    {
        public void Process(AbsentDateRangeModel source, List<AbsentInDayModel> destination, ResolutionContext context)
        {
            DateOnly iterating = source.From < source.To ? source.From : source.To;     
            DateOnly end = source.From < source.To ? source.To : source.From;
            while (true)
            {
                var absentInDay = new AbsentInDayModel()
                {
                    Option = Models.Enum.Timetable.AbsentOption.AllDay,
                    Reason = source.Reason,
                    SelectedDate = iterating,
                    TrainerId = source.TrainerId,
                };
                destination.Add(absentInDay);
                if (iterating >= end)
                    break;
                else
                    iterating = iterating.AddDays(1);
            }
        }
    }
    public class MappingAction_AbsentInDayModel_TrainerSlot : IMappingAction<AbsentInDayModel, TrainerSlot>
    {
        public void Process(AbsentInDayModel source, TrainerSlot destination, ResolutionContext context)
        {
            destination.TrainerId = source.TrainerId;
            destination.Reason = source.Reason;
            //destination.SlotId = source.SlotId;
            destination.Date = source.SelectedDate.ToDateTime(new TimeOnly());
            destination.EntityTypeId = (int)source.EntityTypeId;
            destination.Status = (int)source.Status;
        }
    }
        public class MappingAction_Trainer_TrainerModel : IMappingAction<Trainer, TrainerModel>
    {
        private readonly IMapper _mapper;
        public MappingAction_Trainer_TrainerModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        public void Process(Trainer source, TrainerModel destination, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Name = source.User.Name;
            destination.Email = source.User.Email;
            destination.Avatar = source.User.Avatar;
            destination.PhoneNumber = source.User.PhoneNumber.ToString();
            List<TrainerSkillModel> trainerSkillModels = new List<TrainerSkillModel>();
            foreach (TrainerSkill skill in source.TrainerSkills)
            {
                var trainerSkillModel = _mapper.Map<TrainerSkillModel>(skill);
                trainerSkillModels.Add(trainerSkillModel);
            }
            destination.Status = (Models.Enum.Trainer.Status)source.Status;
            destination.Skills = trainerSkillModels;
        }
    }
    public class MappingAction_TrainerSlot_TimetableModel : IMappingAction<TrainerSlot, TimetableModel>
    {
        public void Process(TrainerSlot source, TimetableModel destination, ResolutionContext context)
        {
           
            destination.Start = source.Date + source.Slot.StartTime.Value;
            destination.End = source.Date + source.Slot.EndTime.Value;
            destination.Date = source.Date;
            destination.Id = source.Id;
            destination.EntityId = source.EntityId;
            destination.SlotId = source.SlotId;
            destination.Title = source.Reason;            
            destination.TypeId = source.EntityTypeId;
            
            destination.TypeName = (Models.Enum.EntityType)source.EntityTypeId;

            if (source.EntityTypeId == (int)Models.Enum.EntityType.AbsentRequest)
            {
                destination.Reason = source.Reason;
                destination.Title = "Off Slot";
            }
        }
    }
}
