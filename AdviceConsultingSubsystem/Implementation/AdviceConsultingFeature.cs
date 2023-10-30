using AppRepository.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AdviceConsultingSubsystem.Implementation
{
    public class AdviceConsultingFeature : IAdviceConsultingFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdviceConsultingFeature (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IFeatureCustomer Customer => new FeatureCustomer(_unitOfWork, _mapper);

        public IFeatureStaff Staff => new FeatureStaff(_unitOfWork, _mapper);

        public IFeatureTrainer Trainer => new FeatureTrainer(_unitOfWork, _mapper);
        public IOtherFeature Other => new OtherFeature(_unitOfWork, _mapper);
    }
}
