using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureAll : IFeatureAll
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureAll(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BirdSpeciesModel>> GetBirdSpecies()
        {
            var entities = await _unitOfWork.BirdSpeciesRepository.Get();
            var models = _mapper.Map<IEnumerable<BirdSpeciesModel>>(entities);
            return models;
        }

        public async Task<BirdSpeciesModel> GetBirdSpeciesById(int birdSpeciesId)
        {
            var entity = await _unitOfWork.BirdSpeciesRepository.GetFirst(e => e.Id == birdSpeciesId);
            var model = _mapper.Map<BirdSpeciesModel>(entity);
            return model;
        }

        public IEnumerable<Status> GetEnumBirdTrainingProgressStatuses()
        {
            var statuses = Enum.GetValues(typeof(Models.Enum.BirdTrainingProgress.Status)).Cast<Models.Enum.BirdTrainingProgress.Status>();
            return statuses;
        }
    }
}