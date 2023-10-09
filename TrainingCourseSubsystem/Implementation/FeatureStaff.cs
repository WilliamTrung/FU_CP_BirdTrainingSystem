using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
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

        public async Task Add(BirdTrainingCourseModel birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdTrainingCourse>(birdTrainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingCourseRepository.Add(entity);
        }

        public async Task Add(BirdTrainingProgressModel birdTrainingProgress)
        {
            if (birdTrainingProgress == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdTrainingProgress>(birdTrainingProgress);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingProgressRepository.Add(entity);
        }

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourse()
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdTrainingCourseModel>> GetBirdTrainingCourseByBirdId(int birdId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(e => e.BirdId == birdId);
            var models = _mapper.Map<IEnumerable<BirdTrainingCourseModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainer()
        {
            var entities = await _unitOfWork.TrainerRepository.Get(expression:null, "User", "Skill");
            List<TrainerModel> models = new List<TrainerModel>();
            foreach(Models.Entities.Trainer entity in entities)
            {
                var skills = _mapper.Map<List<TrainerSkillModel>>(entity.TrainerSkills);
                TrainerModel model = new TrainerModel()
                {
                    Id = entity.Id,
                    Name = entity.User.Name,
                    Email= entity.User.Email,
                    Avatar = entity.User.Avatar,
                    Skills = skills
                };
                models.Add(model);
            }
            return models;
        }

        public async Task<TrainerModel> GetTrainerById(int trainerId)
        {
            var entity = await _unitOfWork.TrainerRepository.GetFirst(e => e.Id == trainerId, "User", "Skill");
            var skills = _mapper.Map<List<TrainerSkillModel>>(entity.TrainerSkills);
            TrainerModel model = new TrainerModel()
            {
                Id = entity.Id,
                Name = entity.User.Name,
                Email = entity.User.Email,
                Avatar = entity.User.Avatar,
                Skills = skills
            };
            return model;
        }

        public async Task Update(BirdTrainingCourseModel birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdTrainingCourse>(birdTrainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
        }

        public async Task Update(BirdTrainingProgressModel birdTrainingProgress)
        {
            if (birdTrainingProgress == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdTrainingProgress>(birdTrainingProgress);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdTrainingProgressRepository.Update(entity);
        }
    }
}
