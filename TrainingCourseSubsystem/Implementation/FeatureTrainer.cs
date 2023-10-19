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
    }
}
