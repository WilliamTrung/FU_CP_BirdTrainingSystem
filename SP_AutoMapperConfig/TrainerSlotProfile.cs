using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.TrainerSlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TrainerSlotProfile : Profile
    {
        public TrainerSlotProfile()
        {
            Map_TrainerSlotAddModel_TrainerSlot();
            Map_TrainerSlot_TrainingCourseTrainerSlotModel();
        }

        private void Map_TrainerSlot_TrainingCourseTrainerSlotModel()
        {
            CreateMap<TrainerSlot, TrainingCourseTrainerSlotModel>()
                .ForMember(e => e.Id, opt => opt.MapFrom(m => m.Id))
                .ForMember(e => e.TrainerId, opt => opt.MapFrom(m => m.TrainerId))
                .ForMember(e => e.SlotId, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Date))
                .ForMember(e => e.Reason, opt => opt.MapFrom(m => m.Reason))
                .ForMember(e => e.EntityTypeId, opt => opt.MapFrom(m => m.EntityTypeId))
                .ForMember(e => e.EntityId, opt => opt.MapFrom(m => m.EntityId))
                .ForMember(e => e.Status, opt => opt.MapFrom(m => m.Status));
        }

        private void Map_TrainerSlotAddModel_TrainerSlot()
        {
            CreateMap<TrainerSlotAddModel, TrainerSlot>()
                .ForMember(e => e.SlotId, opt => opt.MapFrom(m => m.SlotId))
                .ForMember(e => e.Date, opt => opt.MapFrom(m => m.Date))
                .ForMember(e => e.Reason, opt => opt.MapFrom(m => m.Reason))
                .ForMember(e => e.EntityTypeId, opt => opt.MapFrom(m => m.EntityTypeId))
                .ForMember(e => e.EntityId, opt => opt.MapFrom(m => m.EntityId))
                .ForMember(e => e.Status, opt => opt.MapFrom(m => m.st);
        }
    }
}
