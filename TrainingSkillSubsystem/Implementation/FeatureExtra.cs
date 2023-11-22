using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
using Models.ServiceModels.TrainingCourseModels.TrainerSkill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSkillSubsystem.Implementation
{
    public class FeatureExtra : IFeatureExtra
    {
        internal readonly IUnitOfWork _uow;
        internal readonly IMapper _mapper;
        public FeatureExtra(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task DeleteAcquirableSkill(AcquirableAddModBirdSkill model)
        {
            var entity = await _uow.AcquirableSkillRepository.GetFirst(c => c.BirdSpeciesId == model.BirdSpeciesId 
                                                                            && c.BirdSkillId == model.BirdSkillId);
            if(entity == null)
            {
                throw new KeyNotFoundException("This species does not have the skill");
            }
            await _uow.AcquirableSkillRepository.Delete(entity);
        }

        public async Task DeleteTrainableSkill(TrainableAddModSkillModel model)
        {
            var entity = await _uow.TrainableSkillRepository.GetFirst(c => c.BirdSkillId == model.BirdSkillId
                                                                            && c.SkillId == model.SkillId);
            if (entity == null)
            {
                throw new KeyNotFoundException("This bird skill does not have that trainer skill");
            }
            await _uow.TrainableSkillRepository.Delete(entity);
        }

        public async Task DeleteTrainerSkill(TrainerSkillAddModModel model)
        {
            var entity = await _uow.TrainerSkillRepository.GetFirst(c => c.TrainerId == model.TrainerId
                                                                          && c.SkillId == model.SkillId);
            if (entity == null)
            {
                throw new KeyNotFoundException("This trainer does not have the skill!");
            }
            await _uow.TrainerSkillRepository.Delete(entity);
        }
    }
}
