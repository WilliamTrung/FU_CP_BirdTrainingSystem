using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureStaff : FeatureUser, IFeatureStaff
    {
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task Add(BirdTrainingCourse birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.BirdTrainingCourse>(birdTrainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingCourseRepository.Add(entity);
        }

        public async Task Add(BirdTrainingProgress birdTrainingProgress)
        {
            if (birdTrainingProgress == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.BirdTrainingProgress>(birdTrainingProgress);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingProgressRepository.Add(entity);
        }

        public async Task<IEnumerable<BirdTrainingCourse>> GetBirdTrainingCourse()
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get();
            var models = _mapper.Map<IEnumerable<Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdTrainingCourse>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(e => e.BirdId == birdId);
            var models = _mapper.Map<IEnumerable<Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse>>(entities);
            return models;
        }

        public async Task<IEnumerable<Trainer>> GetTrainer()
        {
            var entities = await _unitOfWork.TrainerRepository.Get();
            var models = _mapper.Map<IEnumerable<Models.ServiceModels.TrainingCourseModels.Trainer>>(entities);
            return models;
        }

        public async Task<Trainer?> GetTrainerById(int trainerId)
        {
            var entities = await _unitOfWork.TrainerRepository.GetFirst(e => e.Id == trainerId);
            var models = _mapper.Map<Models.ServiceModels.TrainingCourseModels.Trainer>(entities);
            return models;
        }

        public async Task Update(BirdTrainingCourse birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.BirdTrainingCourse>(birdTrainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
        }

        public async Task Update(BirdTrainingProgress birdTrainingProgress)
        {
            if (birdTrainingProgress == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.BirdTrainingProgress>(birdTrainingProgress);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingProgressRepository.Update(entity);
        }
    }
}
