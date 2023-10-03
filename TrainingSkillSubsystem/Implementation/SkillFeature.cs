using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels;
using Models.Skills;
using SP_Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingSkillSubsystem.Implementation
{
    public class SkillFeature : ISkillFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SkillFeature(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<BirdSkillModel>> GetBirdSkillsTrainedByTrainerSkill(string trainerSkillName)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var query = await _unitOfWork.SkillRepository
                .GetFirst(skill => CustomStringFunctions.CompareStringsIgnoreCaseAndWhitespace(skill.Name, trainerSkillName)
                    , "TrainableSkills");
#pragma warning restore CS8604 // Possible null reference argument.
            var models = _mapper.Map<List<BirdSkillModel>>(query);
            return models;
        }

        public async Task<List<TrainerModel>> GetTrainersByBirdSkill(string birdSkillName)
        {
            //get trainer skills by bird skill
            var trainerSkills = await GetTrainerSkillsByBirdSkill(birdSkillName);
            //get trainers by having such trainer skills
            var query_trainerId = await _unitOfWork.TrainerSkillRepository.Get(ts => trainerSkills.Any(c => c.Id == ts.SkillId));
            var query_trainers = await _unitOfWork.TrainerRepository.Get(trainer => query_trainerId.Any(c => c.TrainerId == trainer.Id), "TrainerSkills");
            var models = _mapper.Map<List<TrainerModel>>(query_trainers);
            return models;
        }

        public async Task GetTrainerSkills(int trainerId)
        {
            
        }

        public async Task<List<TrainerSkillModel>> GetTrainerSkillsByBirdSkill(string birdSkillName)
        {
#pragma warning disable CS8604 // Possible null reference argument.
            var query = await _unitOfWork.BirdSkillRepository
                .GetFirst(birdSkill => CustomStringFunctions.CompareStringsIgnoreCaseAndWhitespace(birdSkill.Name, birdSkillName)
                    , "TrainableSkills");
#pragma warning restore CS8604 // Possible null reference argument.
            var models = _mapper.Map<List<TrainerSkillModel>>(query);
            return models;
        }
    }
}
