using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TrainingCourseProfile : Profile
    {
        public TrainingCourseProfile()
        {
            Map_TrainingCourseAddModel_TrainingCourse();
            Map_TrainingCourse_TrainingCourseViewModel();
            Map_AddTrainingSkillModel_TrainingSkillModel();
        }

        private void Map_AddTrainingSkillModel_TrainingSkillModel()
        {
            CreateMap<AddTrainingSkillModel, TrainingCourseSkill>()
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => e.TotalSlot))
                .ForMember(m => m.TrainingCourseId, opt => opt.MapFrom(e => e.TrainingCourseId));
        }

        private void Map_TrainingCourse_TrainingCourseViewModel()
        {
            CreateMap<TrainingCourse, TrainingCourseViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.BirdSpeciesName, opt => {
                    opt.PreCondition(m => m.BirdSpecies != null);
                    opt.MapFrom(e => e.BirdSpecies.Name); 
                })
                .ForMember(m => m.Title, opt => opt.MapFrom(e => e.Title))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture))
                .ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => e.TotalSlot))
                .ForMember(m => m.TotalPrice, opt => opt.MapFrom(e => e.TotalPrice));
        }

        private void Map_TrainingCourseAddModel_TrainingCourse()
        {
            CreateMap<TrainingCourseAddModel, TrainingCourse>()
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.Title, opt => opt.MapFrom(e => e.Title))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(m => m.Picture, opt => opt.MapFrom(e => e.Picture))
                .ForMember(m => m.TotalPrice, opt => opt.MapFrom(e => e.TotalPrice))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => (int)Models.Enum.TrainingCourse.Status.Modifying))
                .ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => 0));
        }
    }
}
