using AutoMapper;
using Models.Entities;
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
                .ForMember(m => m.Name, opt => {
                    opt.PreCondition(e => e.User != null);
                    opt.MapFrom(e => e.User.Name);
                })
                .ForMember(m => m.Email, opt => {
                    opt.PreCondition(e => e.User != null);
                    opt.MapFrom(e => e.User.Email);
                })
                .ForMember(m => m.Avatar, opt => {
                    opt.PreCondition(e => e.User != null);
                    opt.MapFrom(e => e.User.Avatar);
                });
        }
    }
}
