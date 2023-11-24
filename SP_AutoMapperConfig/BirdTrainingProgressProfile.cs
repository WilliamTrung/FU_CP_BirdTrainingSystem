using AppRepository.UnitOfWork;
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
            CreateMap<GenerateCourseProgress, BirdTrainingProgress>()
                //.ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.BirdTrainingCourseId, opt => opt.MapFrom(e => e.BirdTrainingCourseId))
                .ForMember(m => m.TrainingCourseSkillId, opt => opt.MapFrom(e => e.TrainingCourseSkillId));
        }
        private void Map_BirdTrainingProgress_BirdTrainingProgressViewModel()
        {
            CreateMap<BirdTrainingProgress, BirdTrainingProgressViewModel>()
                .AfterMap<MapAction_BirdTrainingProgress_BirdTrainingProgressViewModel>();
            //        .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
            //        .ForMember(m => m.BirdTrainingCourseId, opt => opt.MapFrom(e => e.BirdTrainingCourseId))
            //        .ForMember(m => m.SkillName, opt => {
            //            opt.PreCondition(e => e.TrainingCourseSkill != null);
            //            opt.PreCondition(e => e.TrainingCourseSkill.BirdSkill != null);
            //            opt.MapFrom(e => e.TrainingCourseSkill.BirdSkill.Name);
            //        })
            //        .ForMember(m => m.TrainerId, opt => opt.MapFrom(e => e.TrainerId))
            //        .ForMember(m => m.TrainerName, opt => {
            //            opt.PreCondition(e => e.Trainer != null);
            //            opt.PreCondition(e => e.Trainer.User != null);
            //            opt.MapFrom(e => e.Trainer.User.Name);
            //        })
            //        .ForMember(m => m.Evidence, opt => opt.MapFrom(e => e.Evidence))
            //        .ForMember(m => m.TotalTrainingSlot, opt => opt.MapFrom(e => e.TotalTrainingSlot))
            //        .ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status));
        }
        public class MapAction_BirdTrainingProgress_BirdTrainingProgressViewModel : IMappingAction<BirdTrainingProgress, BirdTrainingProgressViewModel>
        {
            private readonly IUnitOfWork _unitOfWork;
            public MapAction_BirdTrainingProgress_BirdTrainingProgressViewModel(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }

            public void Process(BirdTrainingProgress source, BirdTrainingProgressViewModel destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                destination.BirdTrainingCourseId = source.BirdTrainingCourseId;
                destination.TrainingCourseSkillId = source.TrainingCourseSkillId;
                destination.TrainerId = source.TrainerId;
                destination.Evidence = source.Evidence;
                destination.TotalTrainingSlot = source.TotalTrainingSlot;
                destination.Status = (Models.Enum.BirdTrainingProgress.Status)source.Status;

                var skill = _unitOfWork.TrainingCourseSkillRepository.GetFirst(e => e.Id == source.TrainingCourseSkillId
                                                                                , nameof(TrainingCourseSkill.BirdSkill)).Result;
                if (skill != null)
                {
                    destination.BirdSkillId = skill.BirdSkill.Id;
                    destination.BirdSkillName = skill.BirdSkill.Name;
                    destination.BirdSkillPicture = skill.BirdSkill.Picture;
                }
                if (source.TrainerId != null)
                {
                    var trainer = _unitOfWork.TrainerRepository.GetFirst(e => e.Id == source.TrainerId
                                                                            , nameof(Trainer.User)).Result;
                    if (trainer != null)
                    {
                        destination.TrainerId = source.TrainerId;
                        destination.TrainerName = trainer.User.Name;
                    }
                }
                else
                {
                    destination.TrainerId = null;
                    destination.TrainerName = null;
                }

                var reports = _unitOfWork.BirdTrainingReportRepository.Get(e => e.BirdTrainingProgressId == source.Id
                                                                            && e.Status == (int)Models.Enum.BirdTrainingReport.Status.Done).Result.ToList();
                if (reports == null)
                {
                    destination.TrainingProgression = 0;
                }
                else
                {
                    if (reports.Count == 0)
                    {
                        destination.TrainingProgression = 0;
                    }
                    else
                    {
                        double doneReport = (double)reports.Count;
                        double progression = doneReport / source.TotalTrainingSlot;
                        double progressionRounded = Math.Round(progression, 4);
                        destination.TrainingProgression = progressionRounded;
                    }
                }
            }
        }
    }
}