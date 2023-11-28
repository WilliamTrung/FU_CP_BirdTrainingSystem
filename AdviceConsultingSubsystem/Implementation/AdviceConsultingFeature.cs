using AppRepository.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimetableSubsystem;
using TransactionSubsystem;

namespace AdviceConsultingSubsystem.Implementation
{
    public class AdviceConsultingFeature : IAdviceConsultingFeature
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITimetableFeature _timetable;

        public AdviceConsultingFeature (IUnitOfWork unitOfWork, IMapper mapper, ITimetableFeature timetable)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _timetable = timetable;
        }

        public IFeatureCustomer Customer => new FeatureCustomer(_unitOfWork, _mapper, _timetable);

        public IFeatureStaff Staff => new FeatureStaff(_unitOfWork, _mapper);

        public IFeatureTrainer Trainer => new FeatureTrainer(_unitOfWork, _mapper);
        public IOtherFeature Other => new OtherFeature(_unitOfWork, _mapper);
    }
}
