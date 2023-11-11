using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.Enum.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdCertificate;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
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

        public async Task<IEnumerable<BirdCertificateViewModel>> GetBirdCertificates()
        {
            var entities = await _unitOfWork.BirdCertificateRepository.Get();
            var models = _mapper.Map<List<BirdCertificateViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdSpeciesViewModel>> GetBirdSpecies()
        {
            var entities = await _unitOfWork.BirdSpeciesRepository.Get();
            var models = _mapper.Map<List<BirdSpeciesViewModel>>(entities);
            return models;
        }

        public async Task<BirdSpeciesViewModel> GetBirdSpeciesById(int birdSpeciesId)
        {
            var entity = await _unitOfWork.BirdSpeciesRepository.GetFirst(e => e.Id == birdSpeciesId);
            var model = _mapper.Map<BirdSpeciesViewModel>(entity);
            return model;
        }

        public IEnumerable<Status> GetEnumBirdTrainingProgressStatuses()
        {
            var statuses = Enum.GetValues(typeof(Models.Enum.BirdTrainingProgress.Status)).Cast<Models.Enum.BirdTrainingProgress.Status>();
            return statuses;
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourses()
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get(expression: null, nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            return models;
        }

        public async Task<TrainingCourseViewModel> GetTrainingCoursesById(int courseId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == courseId
                                                                               , nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<TrainingCourseViewModel>(entities);
            return models;
        }
    }
}