using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
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
            var entities = await _unitOfWork.TrainerRepository.Get(expression:null, nameof(User), nameof(TrainerSkill));
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
                    TrainerSkillModels = skills
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
                TrainerSkillModels = skills
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

        public async Task<IEnumerable<TrainerModel>> GetTrainerByTrainerSkillId(int trainerSkillId)
        {
            var trainerSkills = await _unitOfWork.TrainerSkillRepository.Get(e => e.SkillId == trainerSkillId, nameof(Trainer));
            List<Trainer> trainerEntities = new List<Trainer>();
            foreach (var trainerSkill in trainerSkills)
            {
                if(trainerSkill.Trainer != null)
                {
                    trainerEntities.Add(trainerSkill.Trainer);
                }
            }
            var models = _mapper.Map<IEnumerable<TrainerModel>>(trainerEntities);
            return models;
        }

        public async Task<IEnumerable<TrainerModel>> GetTrainerByBirdSkillId(int birdSkillId)
        {
            var trainableSkills = await _unitOfWork.TrainableSkillRepository.Get(e => e.BirdSkillId == birdSkillId);
            List<TrainerModel> models = new List<TrainerModel>();
            foreach(var trainableSkill in trainableSkills)
            {
                var trainerSkillId = trainableSkill.SkillId;
                List<TrainerModel> trainers = GetTrainerByTrainerSkillId(trainerSkillId).Result.ToList();
                foreach (var trainer in trainers)
                {
                    if(trainer != null)
                    {
                        models.Add(trainer);
                    }
                }
            }
            models.DistinctBy(m => m.Id).ToList();
            return models;
        }

        public async Task InitStartTime(BirdTrainingCourseStartTime birdTrainingCourse)
        {
            if(birdTrainingCourse == null)
            {
                throw new Exception("Client send null param");
            }
            else
            {
                var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourse.Id);
                if (entity == null)
                {
                    throw new Exception("Entity not found");
                }
                else
                {
                    entity.StaffId = birdTrainingCourse.StaffId;
                    entity.ExpectedStartDate = birdTrainingCourse.ExpectedStartDate;
                    entity.ExpectedTrainingDoneDate = birdTrainingCourse.ExpectedTrainingDoneDate;
                    entity.ExpectedDateReturn = birdTrainingCourse.ExpectedDateReturn;
                    entity.LastestUpdate = DateTime.Now;
                    entity.Status = (int) Models.Enum.BirdTrainingCourse.Status.AssignedTrainerToCourse;

                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                }
            }
        }

        public async Task ReceiveBird(BirdTrainingCourseReceiveBird birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null param");
            }
            else
            {
                var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourse.Id);
                if (entity == null)
                {
                    throw new Exception("Entity not found");
                }
                else
                {
                    entity.ReceiveStaffId = birdTrainingCourse.ReceiveStaffId;
                    entity.DateReceivedBird = DateTime.Now;
                    entity.ReceiveNote = birdTrainingCourse.ReceiveNote;
                    entity.ReceivePicture = birdTrainingCourse.ReceivePicture;
                    entity.LastestUpdate = DateTime.Now;
                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.ReceivedBirdFromCustomer; //enum birdtrainingcourse status
                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                }
            }
        }

        public async Task ReturnBird(BirdTrainingCourseReturnBird birdTrainingCourse)
        {
            if (birdTrainingCourse == null)
            {
                throw new Exception("Client send null param");
            }
            else
            {
                var entity = await _unitOfWork.BirdTrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourse.Id);
                if (entity == null)
                {
                    throw new Exception("Entity not found");
                }
                else
                {
                    entity.ReturnStaffId = birdTrainingCourse.ReturnStaffId;
                    entity.DateReceivedBird = DateTime.Now;
                    entity.ReturnNote = birdTrainingCourse.ReturnNote;
                    entity.ReturnPicture = birdTrainingCourse.ReturnPicture;
                    entity.LastestUpdate = DateTime.Now;
                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.ReturnedBirdToCustomer;
                    await _unitOfWork.BirdTrainingCourseRepository.Update(entity);
                }
            }
        }

        public async Task AssignTrainer(AssignTrainerToCourse assignTrainer)
        {
            if(assignTrainer == null)
            {
                throw new Exception("Client send null models");
            }
            else
            {
                var entity = _mapper.Map<BirdTrainingProgress>(assignTrainer);
                entity.IsComplete = false;
                await _unitOfWork.BirdTrainingProgressRepository.Add(entity);
            }
        }
    }
}
