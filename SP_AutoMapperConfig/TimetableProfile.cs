using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.WorkshopModels;
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
        private void Map_Slot_SlotModel()
        {
            CreateMap<Slot,SlotModel>();
        }
        private void Map_TrainerSlot_SlotModel()
        {
            CreateMap<TrainerSlot, SlotModel>()
                .ForMember(m => m, opt =>
                {
                    opt.PreCondition(e => e.Slot != null);
                    opt.MapFrom(e => e.Slot);
                });
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
}
