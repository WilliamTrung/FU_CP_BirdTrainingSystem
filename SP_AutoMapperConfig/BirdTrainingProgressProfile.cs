using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdTrainingProgressProfile : Profile
    {
        public BirdTrainingProgressProfile()
        {
            Map_BirdTrainingProgress_GenerateCourseProgress();
            Map_BirdTrainingProgress_BirdTrainingProgressViewModel();
        }
        private void Map_BirdTrainingProgress_GenerateCourseProgress()
        {
            CreateMap<BirdTrainingProgress, GenerateCourseProgress>()
                //.ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.BirdTrainingCourseId, opt => opt.MapFrom(e => e.BirdTrainingCourseId))
                .ForMember(m => m.TrainingCourseSkillId, opt => opt.MapFrom(e => e.TrainingCourseSkillId));
        }
        private void Map_BirdTrainingProgress_BirdTrainingProgressViewModel()
        {
            CreateMap<BirdTrainingProgress, BirdTrainingProgressViewModel>()
                //.ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.SkillName, opt => {
                    opt.PreCondition(e => e.TrainingCourseSkill != null);
                    opt.PreCondition(e => e.TrainingCourseSkill.BirdSkill != null);
                    opt.MapFrom(e => e.TrainingCourseSkill.BirdSkill.Name);
                })
                .ForMember(m => m.TrainerName, opt => {
                    opt.PreCondition(e => e.Trainer != null);
                    opt.PreCondition(e => e.Trainer.User != null);
                    opt.MapFrom(e => e.Trainer.User.Name);
                })
                .ForMember(m => m.Evidence, opt => opt.MapFrom(e => e.Evidence))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status));
        }
    }
}