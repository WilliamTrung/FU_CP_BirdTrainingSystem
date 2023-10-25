using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TrainerSkillProfile : Profile
    {
        public TrainerSkillProfile() {
            Map_TrainerSkill_TrainerSkillModel();
        }
        private void Map_TrainerSkill_TrainerSkillModel()
        {
            CreateMap<TrainerSkill, Models.ServiceModels.TrainerSkillModel>()
                .ForMember(c => c.Id, opt => opt.PreCondition(e => e.Skill != null))
                .AfterMap< MappingAction_TrainerSkill_TrainerSkillModel>();
        }

    }
    public class MappingAction_TrainerSkill_TrainerSkillModel : IMappingAction<TrainerSkill, TrainerSkillModel>
    {
        private readonly IUnitOfWork _uow;
        public MappingAction_TrainerSkill_TrainerSkillModel(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public void Process(TrainerSkill source, TrainerSkillModel destination, ResolutionContext context)
        {
            if(source.Skill == null)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                source.Skill = _uow.SkillRepository.GetFirst(c => c.Id == source.SkillId).Result;
#pragma warning restore CS8601 // Possible null reference assignment.
            }
            destination.Id = source.SkillId;
            destination.Name = source.Skill.Name;
#pragma warning disable CS8601 // Possible null reference assignment.
            destination.Description = source.Skill.Description;
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }
}
