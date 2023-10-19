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
            Map_BirdTrainingProgress_AssignTrainerToCourse();
        }
        private void Map_BirdTrainingProgress_AssignTrainerToCourse()
        {
            CreateMap<BirdTrainingProgress, AssignTrainerToCourse>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.BirdTrainingCourseId, opt => opt.MapFrom(e => e.BirdTrainingCourseId))
                .ForMember(m => m.TrainingCourseSkillId, opt => opt.MapFrom(e => e.TrainingCourseSkillId))
                .ForMember(m => m.TrainerId, opt => opt.MapFrom(e => e.TrainerId));
        }
    }
}
