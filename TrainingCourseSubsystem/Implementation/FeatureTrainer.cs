using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureTrainer : FeatureUser, IFeatureTrainer
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

        public async Task MarkTrainingSkillDone(int birdTrainingProgressId)
        {
            var entity = _unitOfWork.BirdTrainingProgressRepository.GetFirst(e => e.Id == birdTrainingProgressId).Result;
            if(entity == null)
            {
                throw new Exception("Entity not found");
            }
            else
            {
                entity.TrainingDoneDate = DateTime.Now;
                entity.IsComplete = true;
                await _unitOfWork.BirdTrainingProgressRepository.Update(entity);

                var birdTrainingProgressAll = _unitOfWork.BirdTrainingProgressRepository.Get(e => e.BirdTrainingCourseId == entity.BirdTrainingCourseId).Result.ToList();
                bool allDone = true;
                foreach(BirdTrainingProgress progresss in birdTrainingProgressAll)
                {
                    if (progresss.IsComplete == false)
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