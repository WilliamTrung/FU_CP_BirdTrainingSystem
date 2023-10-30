using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.SlotModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdTrainingReportProfile : Profile
    {
        public BirdTrainingReportProfile()
        {
            Map_BirdTrainingReport_BirdTrainingReportViewModel();
            Map_BirdTrainingReport_InitReportTrainerSlot();
            Map_BirdTrainingReport_TimetableReportView();
        }

        private void Map_BirdTrainingReport_BirdTrainingReportViewModel()
        {
            CreateMap<BirdTrainingReport, BirdTrainingReportViewModel>()
                .ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status))
                .ForMember(m => m.TrainingDate, opt => {
                    opt.PreCondition(e => e.TrainerSlot != null);
                    opt.MapFrom(e => e.TrainerSlot.Date);
                });
        }
        private void Map_BirdTrainingReport_InitReportTrainerSlot()
        {
            CreateMap<BirdTrainingReport, InitReportTrainerSlot>()
                .ForMember(m => m.TrainerId, opt => opt.MapFrom(e => e.TrainerId))
                .ForMember(m => m.BirdTrainingProgressId, opt => opt.MapFrom(e => e.BirdTrainingProgressId))
                .ForMember(m => m.TrainerSlotId, opt => opt.MapFrom(e => e.TrainerSlotId));
        }

        public class MapAction_BirdTrainingReport_TimetableReportView : IMappingAction<BirdTrainingReport, TimetableReportView>
        {
            private readonly IUnitOfWork _unitOfWork;
            public MapAction_BirdTrainingReport_TimetableReportView(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public void Process(BirdTrainingReport source, TimetableReportView destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                var birdTrainingProgress = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == source.BirdTrainingProgressId
                                                                                                ,nameof(BirdTrainingProgress.BirdTrainingCourse)).Result;
                var skill = _unitOfWork.SkillRepository.GetFirst(e => e.Id == birdTrainingProgress.TrainingCourseSkillId).Result;
                var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingProgress.BirdTrainingCourse.BirdId
                                                                ,nameof(Bird.BirdSpecies)).Result;
                destination.SkillName = skill.Name;
                destination.SkillDescription = skill.Description;
                destination.BirdName = bird.Name;
                destination.BirdSpeciesName = bird.BirdSpecies.Name;
                destination.BirdColor = bird.Color;
                destination.BirdPicture = bird.Picture;
            }
        }

        private void Map_BirdTrainingReport_TimetableReportView()
        {
            CreateMap<BirdTrainingReport, TimetableReportView>()
                .AfterMap<MapAction_BirdTrainingReport_TimetableReportView>();
        }
    }
}
