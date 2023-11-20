using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.TrainingCourseModels.BirdSkill;
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
    }
}
