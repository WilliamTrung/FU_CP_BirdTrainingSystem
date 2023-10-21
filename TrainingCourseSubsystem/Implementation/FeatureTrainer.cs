using AppRepository.UnitOfWork;
using AutoMapper;
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
            }
        }
    }
}