using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdSkillProfile : Profile
    {
        public BirdSkillProfile()
        {
            Map_BirdSkillAddModel_BirdSkill();
            Map_BirdSkill_BirdSkillViewModel();
        }

        private void Map_AcquirableSkill_AcquirableSkillViewModel()
        {
            CreateMap<AcquirableSkill, AcquirableSkillViewModel>()
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.BirdSpeciesName, opt => {
                    opt.PreCondition(e => e.BirdSpecies != null);
                    opt.MapFrom(e => e.BirdSpecies.Name);
                })
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.BirdSkillName, opt => {
                    opt.PreCondition(e => e.BirdSkill!= null);
                    opt.MapFrom(e => e.BirdSkill.Name);
                })
                .ForMember(m => m.Condition, opt => opt.MapFrom(e => e.Condition));
        }

        private void Map_AccquirableAddModBirdSkill_AcquirableSkill()
        {
            CreateMap<AccquirableAddModBirdSkill, AcquirableSkill>()
                .ForMember(m => m.BirdSpeciesId, opt => opt.MapFrom(e => e.BirdSpeciesId))
                .ForMember(m => m.BirdSkillId, opt => opt.MapFrom(e => e.BirdSkillId))
                .ForMember(m => m.Condition, opt => opt.MapFrom(e => e.Condition));
        }

        private void Map_BirdSkill_BirdSkillViewModel()
        {
            CreateMap<BirdSkill, BirdSkillViewModel>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description));
        }

        private void Map_BirdSkillAddModel_BirdSkill()
        {
            CreateMap<BirdSkillAddModel, BirdSkill>()
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.Description, opt => opt.MapFrom(e => e.Description));
        }
    }
}
