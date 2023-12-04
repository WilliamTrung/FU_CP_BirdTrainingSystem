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
            Map_BirdTrainingReport_ReportModifyViewModel();
        }

        private void Map_BirdTrainingReport_ReportModifyViewModel()
        {
            CreateMap<BirdTrainingReport, ReportModifyViewModel>()
                .AfterMap<MapAction_BirdTrainingReport_ReportModifyViewModel>();
                //.ForMember(m => m.ReportId, opt => opt.MapFrom(e => e.Id))
                //.ForMember(m => m.SlotId, opt => {
                //    opt.PreCondition(e => e.TrainerSlot != null);
                //    opt.MapFrom(e => e.TrainerSlot.SlotId);
                //})
                //.ForMember(m => m.Date, opt => {
                //    opt.PreCondition(e => e.TrainerSlot != null);
                //    opt.MapFrom(e => e.TrainerSlot.Date);
                //})
                //.ForMember(m => m.TrainerId, opt => {
                //    opt.PreCondition(e => e.TrainerSlot != null);
                //    opt.MapFrom(e => e.TrainerSlot.TrainerId);
                //});
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
            CreateMap<InitReportTrainerSlot, BirdTrainingReport>()
                .ForMember(m => m.BirdTrainingProgressId, opt => opt.MapFrom(e => e.BirdTrainingProgressId))
                .ForMember(m => m.TrainerSlotId, opt => opt.MapFrom(e => e.TrainerSlotId));
        }

        private void Map_BirdTrainingReport_TimetableReportView()
        {
            CreateMap<BirdTrainingReport, TimetableReportView>()
                .AfterMap<MapAction_BirdTrainingReport_TimetableReportView>();
        }

        public class MapAction_BirdTrainingReport_ReportModifyViewModel : IMappingAction<BirdTrainingReport, ReportModifyViewModel>
        {
            private readonly IUnitOfWork _unitOfWork;
            public MapAction_BirdTrainingReport_ReportModifyViewModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public void Process(BirdTrainingReport source, ReportModifyViewModel destination, ResolutionContext context)
            {
                destination.ReportId = source.Id;
                var trainerSlot = _unitOfWork.TrainerSlotRepository.GetFirst(e => e.Id == source.TrainerSlotId).Result;
                if(trainerSlot != null)
                {
                    destination.SlotId = trainerSlot.SlotId;
                    destination.Date = trainerSlot.Date;
                    if(trainerSlot.TrainerId != null)
                    {
                        var trainer = _unitOfWork.TrainerRepository.GetFirst(e => e.Id == trainerSlot.TrainerId
                                                                                , nameof(Trainer.User)).Result;
                        destination.TrainerId = trainer.Id;
                        destination.TrainerName = trainer.User.Name;
                        destination.TrainerEmail = trainer.User.Email;
                    }
                }
                if (source.Status != null)
                {
                    destination.Status = (Models.Enum.BirdTrainingReport.Status)source.Status;
                }
                else
                {
                    destination.Status = Models.Enum.BirdTrainingReport.Status.NotYet;
                }
            }
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
                                                                                                , nameof(BirdTrainingProgress.BirdTrainingCourse)).Result;
                var skill = _unitOfWork.TrainingCourseSkillRepository.GetFirst(e => e.Id == birdTrainingProgress.TrainingCourseSkillId
                                                                                , nameof(TrainingCourseSkill.BirdSkill)).Result;
                var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingProgress.BirdTrainingCourse.BirdId
                                                                , nameof(Bird.BirdSpecies)).Result;
                destination.BirdSkillName = skill.BirdSkill.Name;
                destination.BirdSkillDescription = skill.BirdSkill.Description;
                destination.BirdName = bird.Name ?? "";
                destination.BirdSpeciesName = bird.BirdSpecies.Name;
                destination.BirdColor = bird.Color;
                destination.BirdPicture = bird.Picture;
                destination.SlotId = source.TrainerSlot.SlotId;
                destination.TrainingDate = source.TrainerSlot.Date;
                if (source.Status != null)
                {
                    destination.Status = (Models.Enum.BirdTrainingReport.Status)source.Status;
                }
                else
                {
                    destination.Status = Models.Enum.BirdTrainingReport.Status.NotYet;
                }
            }
        }
    }
}
