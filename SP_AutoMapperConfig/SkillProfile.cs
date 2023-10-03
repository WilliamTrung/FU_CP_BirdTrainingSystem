using AutoMapper;
using Models.Entities;
using Models.Skills;
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
            SetTrainerSkillProfile();
            SetBirdSkillsBySkill();
            SetTrainerSkillByBirdSkill();
            SetTrainerModel();
        }
        private void SetBirdSkillsBySkill()
        {
            CreateMap<Models.Entities.Skill, List<Models.Skills.BirdSkillModel>>()
                .ForMember(model => model, opt =>
                {
                    opt.PreCondition(c => c.TrainableSkills != null);
                    opt.MapFrom<SkillToListBirdSkillModelResolve>();
                });
        }
        private void SetTrainerSkillByBirdSkill()
        {
            CreateMap<Models.Entities.BirdSkill, List<Models.Skills.TrainerSkillModel>>()
                .ForMember(model => model, opt =>
                {
                    opt.PreCondition(c => c.TrainableSkills != null);
                    opt.MapFrom<BirdSkillToListTrainerSkillModelResolve>();
                });
        }
        private void SetTrainerModel()
        {
            CreateMap<Trainer, Models.ServiceModels.TrainerModel>()
                .ForMember(model => model, opt =>
                {
                    opt.PreCondition(c => c.TrainerSkills != null);
                    opt.MapFrom<Trainer_TrainerModelResolver>();
                });
        }
        private void SetTrainerSkillProfile()
        {
            CreateMap<Models.Entities.TrainableSkill, Models.Skills.TrainerSkillModel>()
                .ForMember(model => model.Name, opt =>
                {
                    opt.PreCondition(c => c.Skill != null);
                    opt.MapFrom(c => c.Skill.Name);
                })
                .ForMember(model => model.Description, opt =>
                {
                    opt.PreCondition(c => c.Skill != null);
                    opt.MapFrom(c => c.Skill.Description);
                })
                .ForMember(model => model.BirdSkills, opt => opt.Ignore());

            CreateMap<Models.Entities.Skill, Models.Skills.TrainerSkillModel>()
                .ForMember(model => model.Name, opt =>
                {                    
                    opt.MapFrom(c => c.Name);
                })
                .ForMember(model => model.Description, opt =>
                {
                    opt.MapFrom(c => c.Description);
                })
                .ForMember(model => model.BirdSkills, opt =>
                {
                    opt.PreCondition(c => c.TrainableSkills != null);
                    opt.MapFrom<ListBirdSkillsToTrainerSkillModelResolve>(); 
                });
        }
    }
    public class Trainer_TrainerModelResolver : IValueResolver<Trainer, Models.ServiceModels.TrainerModel, Models.ServiceModels.TrainerModel>
    {
        public Models.ServiceModels.TrainerModel Resolve(Trainer source, Models.ServiceModels.TrainerModel destination, Models.ServiceModels.TrainerModel destMember, ResolutionContext context)
        {
            destination.Id = source.Id;
            destination.Gender = source.Gender.HasValue?source.Gender.Value:false;
            destination.IsFullTime = source.IsFullTime.HasValue ? source.IsFullTime.Value : true;
            destination.Status = source.Status.HasValue ? (Models.Enum.Trainer.Status) source.Status.Value : Models.Enum.Trainer.Status.Working;
            destination.BirthDay = source.BirthDay;            
            var trainerSkills = source.TrainerSkills;
            foreach (var trainerSkill in trainerSkills)
            {
                destination.Skills.Add(new TrainerSkillModel()
                {
                    Id = trainerSkill.Skill.Id,
                    Name = trainerSkill.Skill.Name,
                    Description = trainerSkill.Skill.Description,    
                    BirdSkills = trainerSkill.Skill.TrainableSkills.Select(c => new BirdSkillModel()
                    {
                        Id = c.BirdSkill.Id,
                        Name = c.BirdSkill.Name,
                        Description = c.BirdSkill.Description,
                    }).ToList(),
                });
            }
            return destination;
        }
    }
    public class BirdSkillToListTrainerSkillModelResolve : IValueResolver<Models.Entities.BirdSkill, List<Models.Skills.TrainerSkillModel>, List<TrainerSkillModel>>
    {
        public List<TrainerSkillModel> Resolve(BirdSkill source, List<TrainerSkillModel> destination, List<TrainerSkillModel> destMember, ResolutionContext context)
        {
            List<TrainerSkillModel> result = new List<TrainerSkillModel>();
            var trainableSkills = source.TrainableSkills;
            foreach (var trainableSkill in trainableSkills)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                var trainerSkillModel = new TrainerSkillModel()
                {
                    Id = trainableSkill.Skill.Id,
                    Name = trainableSkill.Skill.Name,
                    Description = trainableSkill.Skill.Description
                };
#pragma warning restore CS8601 // Possible null reference assignment.
                result.Add(trainerSkillModel);
            }
            return result;
        }
    }
    public class SkillToListBirdSkillModelResolve : IValueResolver<Models.Entities.Skill, List<Models.Skills.BirdSkillModel>, List<BirdSkillModel>>
    {
        public List<BirdSkillModel> Resolve(Skill source, List<BirdSkillModel> destination, List<BirdSkillModel> destMember, ResolutionContext context)
        {
            List<BirdSkillModel> result = new List<BirdSkillModel>();
            var trainableSkills = source.TrainableSkills;
            foreach (var trainableSkill in trainableSkills)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                var birdSkillModel = new BirdSkillModel()
                {
                    Id = trainableSkill.BirdSkill.Id,
                    Name = trainableSkill.BirdSkill.Name,
                    Description = trainableSkill.BirdSkill.Description
                };
#pragma warning restore CS8601 // Possible null reference assignment.
                result.Add(birdSkillModel);
            }
            return result;
        }
    }
    public class ListBirdSkillsToTrainerSkillModelResolve : IValueResolver<Models.Entities.Skill, Models.Skills.TrainerSkillModel, List<BirdSkillModel>>
    {
        List<BirdSkillModel> IValueResolver<Skill, TrainerSkillModel, List<BirdSkillModel>>.Resolve(Skill source, TrainerSkillModel destination, List<BirdSkillModel> destMember, ResolutionContext context)
        {
            List<BirdSkillModel> result = new List<BirdSkillModel>();
            var trainableSkills = source.TrainableSkills;
            foreach (var trainableSkill in trainableSkills)
            {
#pragma warning disable CS8601 // Possible null reference assignment.
                var birdSkillModel = new BirdSkillModel()
                {
                    Id = trainableSkill.BirdSkill.Id,
                    Name = trainableSkill.BirdSkill.Name,
                    Description = trainableSkill.BirdSkill.Description
                };
#pragma warning restore CS8601 // Possible null reference assignment.
                result.Add(birdSkillModel);
            }
            return result;
        }
    }
}
