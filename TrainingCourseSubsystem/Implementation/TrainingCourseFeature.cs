using AppRepository.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class TrainingCourseFeature : ITrainingCourseFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TrainingCourseFeature(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IFeatureCustomer Customer => new FeatureCustomer(_unitOfWork, _mapper);

        public IFeatureManager Manager => new FeatureManager(_unitOfWork, _mapper);

        public IFeatureTrainer Trainer => new FeatureTrainer(_unitOfWork, _mapper);

        public IFeatureStaff Staff => new FeatureStaff(_unitOfWork, _mapper);
    }
}
