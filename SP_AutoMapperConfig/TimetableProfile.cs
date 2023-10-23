using AutoMapper;
using Models.AuthModels;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TimetableModels;
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
                .ForMember(m => m.Id, opt =>
                {
                    opt.MapFrom(e => e.Id);
                })
                .ForMember(m => m.SlotId, opt =>
                {
                    opt.MapFrom(e => e.SlotId);
                })
                .ForMember(m => m.Date, opt =>
                {
                    opt.MapFrom(e => e.Date);
                })
                .ForMember(m => m.Reason, opt =>
                {
                    opt.MapFrom(e => e.Reason);
                })
                .ForMember(m => m.Type, opt =>
                {
                    opt.MapFrom(e => e.EntityTypeId);
                });
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
}
