using AppRepository.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem.Implementation
{
    public class OnlineCourseFeature : IOnlineCourseFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OnlineCourseFeature(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IFeatureCustomer Customer => new FeatureCustomer(_unitOfWork, _mapper);

        public IFeatureStaff Staff => new FeatureStaff(_unitOfWork, _mapper);

        public IFeatureAll All => new FeatureAll(_unitOfWork, _mapper);
    }
}
