using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            Map_SkillAddModel_Skill();
            Map_Skill_SkillViewModModel();
            Map_TrainableAddModModel_TrainableSkill();
            Map_TrainableSkill_TrainableViewSkillModel();
        }

        private void Map_TrainableSkill_TrainableViewSkillModel()
        {
            CreateMap<TrainableSkill, TrainableViewSkillModel>()
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.BirdSkillName, opt => {
                    opt.PreCondition(e => e.BirdSkill != null);
                    opt.MapFrom(e => e.BirdSkill.Name);
                })
                .ForMember(m => m.SkillId, opt => opt.MapFrom(e => e.SkillId))
                .ForMember(m => m.SkillName, opt => {
                    opt.PreCondition(e => e.Skill != null);
                    opt.MapFrom(e => e.Skill.Name);
                })
                .ForMember(m => m.ShortDescription, opt => opt.MapFrom(e => e.ShortDescription));
        }

        private void Map_TrainableAddModModel_TrainableSkill()
        {
            CreateMap<TrainableAddModSkillModel, TrainableSkill>()
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.SkillId, opt => opt.MapFrom(e => e.SkillId))
                .ForMember(m => m.ShortDescription, opt => opt.MapFrom(e => e.ShortDescription));
        }

        private void Map_Skill_SkillViewModModel()
        {
            CreateMap<Skill, SkillViewModModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description));
        }

        private void Map_SkillAddModel_Skill()
        {
            CreateMap<SkillAddModel, Skill>()
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description));
        }
    }
}
