using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureTrainer : FeatureAll, IFeatureTrainer
    {
        public FeatureTrainer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task<IEnumerable<BirdTrainingProgressModel>> GetBirdTrainingProgressByTrainerId(int trainerId)
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get(e => e.TrainerId == trainerId);
            var models = _mapper.Map<IEnumerable<BirdTrainingProgressModel>>(entities);
            return models;
        }

        public async Task<TimetableReportView> GetTimetableReportView(int birdTrainingReportId)
        {
            var entity = await _unitOfWork.BirdTrainingReportRepository.GetFirst(e => e.Id == birdTrainingReportId);
            var model = _mapper.Map<TimetableReportView>(entity);
            return model;
        }

        public async Task MarkTrainingSkillDone(MarkSkillDone markDone)
        {
            var entity = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == markDone.Id).Result;
            if(entity == null)
            {
                throw new Exception("Entity not found");
            }
            else
            {
                entity.Evidence = markDone.Evidence;
                entity.TrainingDoneDate = DateTime.Now;
                entity.Status = (int)Models.Enum.BirdTrainingProgress.Status.Complete;
                await _unitOfWork.BirdTrainingProgressRepository.Update(entity);

                var birdTrainingProgressAll = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == entity.BirdTrainingCourseId).Result.ToList();
                bool allDone = true;
                foreach(BirdTrainingProgress progress in birdTrainingProgressAll)
                {
                    if (progress.Status == (int)Models.Enum.BirdTrainingProgress.Status.Complete)
                    {
                        allDone= false;
                    }
                }
                if (allDone)
                {
                    var birdTrainingCourse = _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == entity.BirdTrainingCourseId).Result;
                    birdTrainingCourse.Status = (int)Models.Enum.BirdTrainingCourse.Status.TrainingDone;

                    var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingCourse.BirdId).Result;
                    bird.Status = (int)Models.Enum.Bird.Status.Ready;

                    await _unitOfWork.BirdTrainingCourseRepository.Update(birdTrainingCourse);
                    await _unitOfWork.BirdRepository.Update(bird);
                }
            }
        }
    }
}