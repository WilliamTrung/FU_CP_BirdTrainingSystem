using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
namespace SP_AutoMapperConfig
{
    public class SlotProfile : Profile
    {
        public SlotProfile()
        {
            Set_TrainerSlot_ClassSlotViewModel();
        }
        private void Set_WorkshopTrainerSlotAddModel_TrainerSlot()
        {
            CreateMap<WorkshopTrainerSlotAddModel, TrainerSlot>()
                .ForMember(e => e.Id, opt => opt.Ignore());
        }
        private void Set_TrainerSlot_ClassSlotViewModel()
        {
            CreateMap<Models.Entities.WorkshopClassDetail, Models.ServiceModels.WorkshopModels.WorkshopClass.ClassSlotViewModel>()
                .ForMember(m => m.StartTime, opt =>
                {
                    opt.PreCondition(e => e.DaySlot != null);
                    opt.MapFrom(e => e.DaySlot.Slot.StartTime);
                })
                .ForMember(m => m.EndTime, opt =>
                {
                    opt.PreCondition(e => e.DaySlot != null);
                    opt.MapFrom(e => e.DaySlot.Slot.EndTime);
                })
                .ForMember(m => m.Detail, opt =>
                {
                    opt.MapFrom(e => e.Detail);
                })
                .ForMember(m => m.Date, opt =>
                {
                    opt.PreCondition(e => e.DaySlot != null);
                    opt.MapFrom(e => e.DaySlot.Date);
                });
        }
    }
}
