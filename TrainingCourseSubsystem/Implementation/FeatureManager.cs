﻿using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureManager : FeatureAll, IFeatureManager
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        #region ManagerMainFunction
        public async Task CreateCourse(TrainingCourseAddModel trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<TrainingCourse>(trainingCourse);
            entity.TotalSlot = 0;
            entity.Status = (int) Models.Enum.TrainingCourse.Status.Modifying;
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.TrainingCourseRepository.Add(entity);
        }
        public async Task EditCourse(TrainingCourseModifyModel trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourse.Id).Result;
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.BirdSpeciesId = trainingCourse.BirdSpeciesId;
                entity.Title = trainingCourse.Title;
                entity.Description = trainingCourse.Description;
                entity.Picture = trainingCourse.Picture;
                entity.TotalPrice = trainingCourse.TotalPrice;
                entity.Status = (int)Models.Enum.TrainingCourse.Status.Modifying;
                await _unitOfWork.TrainingCourseRepository.Update(entity);
            }
        }

        public async Task DisableTrainingCourse(int trainingCourseId)
        {
            var entity = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId).Result;
            if (entity == null)
            {
                throw new Exception("Entity is not found.");
            }
            else
            {
                entity.Status = (int) Models.Enum.TrainingCourse.Status.Disable;
                await _unitOfWork.TrainingCourseRepository.Update(entity);
            }
        }

        public async Task ActiveTrainingCourse(int trainingCourseId)
        {
            var entity = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId).Result;
            if (entity == null)
            {
                throw new Exception("Entity is not found.");
            }
            else
            {
                entity.Status = (int)Models.Enum.TrainingCourse.Status.Active;
                await _unitOfWork.TrainingCourseRepository.Update(entity);
            }
        }

        public async Task AddSkillToCourse(AddTrainingSkillModel trainingCourseSkill)
        {
            if (trainingCourseSkill == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<TrainingCourseSkill>(trainingCourseSkill);
            var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseSkill.TrainingCourseId).Result;
            if(trainingCourse == null)
            {
                throw new Exception("Training Course not found");
            }
            else
            {
                trainingCourse.TotalSlot += entity.TotalSlot;
            }
            if (entity == null)
            {
                throw new Exception("Mapping is failed.");
            }
            await _unitOfWork.TrainingCourseSkillRepository.Add(entity);
            await _unitOfWork.TrainingCourseRepository.Update(trainingCourse);
        }
        public async Task UpdateSkill(AddTrainingSkillModel trainingSkillModel)
        {
            if (trainingSkillModel == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _unitOfWork.TrainingCourseSkillRepository.GetFirst(e => e.BirdSkillId == trainingSkillModel.BirdSkillId
                                                                                && e.TrainingCourseId == trainingSkillModel.TrainingCourseId).Result;
            var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingSkillModel.TrainingCourseId).Result;
            if (trainingCourse == null || entity == null)
            {
                throw new Exception("Training Course not found");
            }
            else
            {
                trainingCourse.TotalSlot -= entity.TotalSlot;
                trainingCourse.TotalSlot += trainingSkillModel.TotalSlot;
            }
            await _unitOfWork.TrainingCourseSkillRepository.Update(entity);
            await _unitOfWork.TrainingCourseRepository.Update(trainingCourse);
        }
        public async Task DeleteSkill(DeleteTrainingSkillModel trainingSkillModel)
        {
            if (trainingSkillModel == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _unitOfWork.TrainingCourseSkillRepository.GetFirst(e => e.BirdSkillId == trainingSkillModel.BirdSkillId
                                                                                && e.TrainingCourseId == trainingSkillModel.TrainingCourseId).Result;
            var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingSkillModel.TrainingCourseId).Result;
            if (trainingCourse == null || entity == null)
            {
                throw new Exception("Training Course not found");
            }
            else
            {
                trainingCourse.TotalSlot -= entity.TotalSlot;
            }
            await _unitOfWork.TrainingCourseSkillRepository.Delete(entity);
            await _unitOfWork.TrainingCourseRepository.Update(trainingCourse);
        }

        public async Task CreateBirdSpecies(BirdSpeciesAddModel birdSpecies)
        {
            if (birdSpecies == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdSpecies>(birdSpecies);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdSpeciesRepository.Add(entity);
        }

        public async Task EditBirdSpecies(BirdSpeciesViewModel birdSpecies)
        {
            if (birdSpecies == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.BirdSpeciesRepository.GetFirst(e => e.Id == birdSpecies.Id);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            entity.Name = birdSpecies.Name;
            entity.ShortDetail = birdSpecies.ShortDetail;
            await _unitOfWork.BirdSpeciesRepository.Update(entity);
        }
        #endregion
        #region ManagerExtendFunction
        public async Task CreateBirdSkill(BirdSkillAddModel birdSkillAdd)
        {
            if (birdSkillAdd == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdSkill>(birdSkillAdd);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdSkillRepository.Add(entity);
        }

        public async Task EditBirdSkill(BirdSkillModModel birdSkillMod)
        {
            if (birdSkillMod == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.BirdSkillRepository.GetFirst(e => e.Id == birdSkillMod.Id);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.Name = birdSkillMod.Name;
                entity.Description = birdSkillMod.Description;
                await _unitOfWork.BirdSkillRepository.Update(entity);
            }
        }

        public async Task<IEnumerable<BirdSkillViewModel>> GetBirdSkills()
        {
            var entities = await _unitOfWork.BirdSkillRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdSkillViewModel>>(entities);
            return models;
        }

        public async Task<BirdSkillViewModel> GetBirdSkillsById(int birdSkillId)
        {
            var entity = await _unitOfWork.BirdSkillRepository.GetFirst(e => e.Id == birdSkillId);
            var model = _mapper.Map<BirdSkillViewModel>(entity);
            return model;
        }

        public async Task CreateAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableAdd)
        {
            if (accquirableAdd == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<AcquirableSkill>(accquirableAdd);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.AcquirableSkillRepository.Add(entity);
        }

        public async Task EditAccquirableBirdSkill(AccquirableAddModBirdSkill accquirableMod)
        {
            if (accquirableMod == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.AcquirableSkillRepository.GetFirst(e => e.BirdSkillId == accquirableMod.BirdSkillId
                                                                                && e.BirdSpeciesId == accquirableMod.BirdSpeciesId);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.Condition = accquirableMod.Condition;
                await _unitOfWork.AcquirableSkillRepository.Update(entity);
            }
        }
        #region TrainerSkillRelate
        public async Task CreateSkill(SkillAddModel skillAddModel)
        {
            if (skillAddModel == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Skill>(skillAddModel);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.SkillRepository.Add(entity);
        }

        public async Task EditSkill(SkillViewModModel skillModModel)
        {
            if (skillModModel == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.SkillRepository.GetFirst(e => e.Id == skillModModel.Id);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.Name = skillModModel.Name;
                entity.Description = skillModModel.Description;
                await _unitOfWork.SkillRepository.Update(entity);
            }
        }
        public async Task<IEnumerable<SkillViewModModel>> GetSkills()
        {
            var entities = await _unitOfWork.SkillRepository.Get();
            var models = _mapper.Map<IEnumerable<SkillViewModModel>>(entities);
            return models;
        }

        public async Task<SkillViewModModel> GetSkillById(int skillId)
        {
            var entity = await _unitOfWork.BirdSkillRepository.GetFirst(e => e.Id == skillId);
            var model = _mapper.Map<SkillViewModModel>(entity);
            return model;
        }

        public async Task CreateTrainerSkill(TrainerSkillAddModModel trainerSkillAdd)
        {
            if (trainerSkillAdd == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<TrainerSkill>(trainerSkillAdd);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.TrainerSkillRepository.Add(entity);
        }

        public async Task EditTrainerSkill(TrainerSkillAddModModel trainerSkillMod)
        {
            if (trainerSkillMod == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.TrainerSkillRepository.GetFirst(e => e.TrainerId == trainerSkillMod.TrainerId
                                                                                && e.SkillId == trainerSkillMod.SkillId);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.Description = trainerSkillMod.Description;
                await _unitOfWork.TrainerSkillRepository.Update(entity);
            }
        }
        public async Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkills()
        {
            var entities = await _unitOfWork.TrainerSkillRepository.Get(expression: null
                                                                        , nameof(TrainerSkill.Skill)
                                                                        , nameof(TrainerSkill.Trainer)
                                                                        , $"{nameof(TrainerSkill.Trainer)}.{nameof(TrainerSkill.Trainer.User)}");
            var models = _mapper.Map<IEnumerable<TrainerSkillViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<TrainerSkillViewModel>> GetTrainerSkillsByTrainerId(int trainerId)
        {
            var entities = await _unitOfWork.TrainerSkillRepository.Get(e => e.TrainerId == trainerId
                                                                        , nameof(TrainerSkill.Skill)
                                                                        , nameof(TrainerSkill.Trainer)
                                                                        , $"{nameof(TrainerSkill.Trainer)}.{nameof(TrainerSkill.Trainer.User)}");
            var models = _mapper.Map<IEnumerable<TrainerSkillViewModel>>(entities);
            return models;
        }

        public async Task CreateTrainableSkill(TrainableAddModSkillModel trainableSkillAdd)
        {
            if (trainableSkillAdd == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<TrainableSkill>(trainableSkillAdd);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.TrainableSkillRepository.Add(entity);
        }

        public async Task EditTrainableSkill(TrainableAddModSkillModel trainableSkillMod)
        {
            if (trainableSkillMod == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.TrainableSkillRepository.GetFirst(e => e.BirdSkillId == trainableSkillMod.BirdSkillId
                                                                                && e.SkillId == trainableSkillMod.SkillId);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.ShortDescription = trainableSkillMod.ShortDescription;
                await _unitOfWork.TrainableSkillRepository.Update(entity);
            }
        }

        public async Task<IEnumerable<TrainableViewSkillModel>> GetTrainableSkills()
        {
            var entities = await _unitOfWork.TrainableSkillRepository.Get(expression: null
                                                                        , nameof(TrainableSkill.Skill)
                                                                        , nameof(TrainableSkill.BirdSkill));
            var models = _mapper.Map<IEnumerable<TrainableViewSkillModel>>(entities);
            return models;
        }
        #endregion
        #endregion
    }
}
