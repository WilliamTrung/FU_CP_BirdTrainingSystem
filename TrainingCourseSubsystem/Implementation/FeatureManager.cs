using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
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
                entity.Description = trainingCourse.Description ?? entity.Description;
                entity.Picture = trainingCourse.Picture ?? entity.Picture;
                entity.TotalPrice = trainingCourse.TotalPrice == 0 ? trainingCourse.TotalPrice : entity.TotalPrice;
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
                var accquirableSkills = _unitOfWork.AcquirableSkillRepository.GetFirst(e => e.BirdSkillId == trainingCourseSkill.BirdSkillId
                                                                                            && e.BirdSpeciesId == trainingCourse.BirdSpeciesId).Result;
                if(accquirableSkills == null)
                {
                    throw new Exception($"Can not add {nameof(BirdSkill)} because it's not suitable for {nameof(BirdSpecies)}");
                }
                trainingCourse.TotalSlot += entity.TotalSlot;
                trainingCourse.Status = (int)Models.Enum.TrainingCourse.Status.Modifying;
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
                trainingCourse.Status = (int)Models.Enum.TrainingCourse.Status.Modifying;
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
                trainingCourse.Status = (int)Models.Enum.TrainingCourse.Status.Modifying;
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
            entity.Name = birdSpecies.Name ?? entity.Name;
            entity.ShortDetail = birdSpecies.ShortDetail ?? entity.ShortDetail;
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
                if(birdSkillMod.Description != null)
                {
                    entity.Description = birdSkillMod.Description;
                }
                if (birdSkillMod.Picture != null)
                {
                    entity.Picture = birdSkillMod.Picture;
                }
                await _unitOfWork.BirdSkillRepository.Update(entity);
            }
        }

        public async Task CreateAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableAdd)
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

        public async Task EditAccquirableBirdSkill(AcquirableAddModBirdSkill accquirableMod)
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
                entity.Condition = accquirableMod.Condition ?? entity.Condition;
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
                entity.Name = skillModModel.Name ?? entity.Name;
                entity.Description = skillModModel.Description ?? entity.Description;
                await _unitOfWork.SkillRepository.Update(entity);
            }
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
                entity.Description = trainerSkillMod.Description ?? entity.Description;
                await _unitOfWork.TrainerSkillRepository.Update(entity);
            }
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
                entity.ShortDescription = trainableSkillMod.ShortDescription ?? entity.ShortDescription;
                await _unitOfWork.TrainableSkillRepository.Update(entity);
            }
        }
        #endregion
        #endregion
        #region BirdCertificate

        public async Task CreateBirdCertitficate(BirdCertificateAddModel birdCertificateAdd)
        {
            if(birdCertificateAdd == null)
            {
                throw new Exception("Client send null param.");
            }
            else
            {
                var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == birdCertificateAdd.TrainingCourseId).Result;
                if(trainingCourse.Status != (int)Models.Enum.TrainingCourse.Status.Active)
                {
                    throw new Exception("Please active training course first.");
                }
                var entity = _mapper.Map<BirdCertificate>(birdCertificateAdd);
                await _unitOfWork.BirdCertificateRepository.Add(entity);

                var skills = _unitOfWork.TrainingCourseSkillRepository.Get(e => e.TrainingCourseId == entity.TrainingCourseId).Result.ToList();
                if(skills != null && skills.Count() > 0)
                {
                    foreach( var skill in skills)
                    {
                        BirdCertificateSkillModifyModel skillModifyModel= new BirdCertificateSkillModifyModel()
                        {
                            BirdCertificateId = entity.Id,
                            BirdSkillId = skill.BirdSkillId
                        };
                        var certificateSkill = _mapper.Map<BirdCertificateSkill>(skillModifyModel);
                        await _unitOfWork.BirdCertificateSkillRepository.Add(certificateSkill);
                    }
                }
            }
        }

        #endregion
    }
}
