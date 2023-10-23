using AutoMapper;
using Models.Entities;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TrainerProfile : Profile
    {
        public TrainerProfile()
        {
            Map_Trainer_TrainerModel();
        }
        private void SetTrainerMapping()
        {

        }
        private void Map_Trainer_TrainerModel()
        {
            CreateMap<Trainer, TrainerModel>()
            //    .ForMember(m => m.Name, opt => {
            //        opt.PreCondition(e => e.User != null);
            //        opt.MapFrom(e => e.User.Name);
            //    })
            //    .ForMember(m => m.Email, opt => {
            //        opt.PreCondition(e => e.User != null);
            //        opt.MapFrom(e => e.User.Email);
            //    })
            //    .ForMember(m => m.Avatar, opt => {
            //        opt.PreCondition(e => e.User != null);
            //        opt.MapFrom(e => e.User.Avatar);
            //    })
            //    .ForMember(m => m.TrainerSkillModels, opt => opt.MapFrom(e => e.TrainerSkills));
            ////CreateMap<Trainer, TrainerModel>()
            ////    .ForMember(m => m, opt => {
            ////        opt.PreCondition(e => e.User != null);
            ////        opt.PreCondition(e => e.TrainerSkills != null);
            ////        opt.MapFrom<Map_Trainer_TrainerModel_Resolver>();
            ////    });
            .AfterMap<MappingAction_Trainer_TrainerModel>();
        }
        //public class Map_Trainer_TrainerModel_Resolver : IValueResolver<Trainer, TrainerModel, TrainerModel>
        //{
        //    private readonly IMapper _mapper;
        //    public Map_Trainer_TrainerModel_Resolver(IMapper mapper)
        //    {
        //        _mapper = mapper;
        //    }

        //    public TrainerModel Resolve(Trainer source, TrainerModel destination, TrainerModel destMember, ResolutionContext context)
        //    {
        //        destination.Id = source.Id;
        //        destination.Name = source.User.Name;
        //        destination.Email = source.User.Email;
        //        destination.Avatar = source.User.Avatar;
        //        List<TrainerSkillModel> trainerSkillModels = new List<TrainerSkillModel>();
        //        foreach (TrainerSkill skill in source.TrainerSkills)
        //        {
        //            var trainerSkillModel = _mapper.Map<TrainerSkillModel>(skill);
        //            trainerSkillModels.Add(trainerSkillModel);
        //        }
        //        destination.TrainerSkillModels = trainerSkillModels;
        //        return destination;
        //    }
        //}
        public class MappingAction_Trainer_TrainerModel : IMappingAction<Trainer, TrainerModel>
        {
            private readonly IMapper _mapper;
            public MappingAction_Trainer_TrainerModel(IMapper mapper)
            {
                _mapper=mapper;
            }
            public void Process(Trainer source, TrainerModel destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                destination.Name = source.User.Name;
                destination.Email = source.User.Email;
                destination.Avatar = source.User.Avatar;
                List<TrainerSkillModel> trainerSkillModels = new List<TrainerSkillModel>();
                foreach (TrainerSkill skill in source.TrainerSkills)
                {
                    var trainerSkillModel = _mapper.Map<TrainerSkillModel>(skill);
                    trainerSkillModels.Add(trainerSkillModel);
                }
                destination.TrainerSkillModels = trainerSkillModels;
            }
        }
    }
}
