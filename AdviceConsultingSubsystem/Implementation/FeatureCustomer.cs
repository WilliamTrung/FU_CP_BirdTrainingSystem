using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.AdviceConsultantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem.Implementation
{
    public class FeatureCustomer : IFeatureCustomer
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task SendConsultingTicket(ConsultingTicket consultingTicket)
        {
            throw new NotImplementedException();

            try
            {
            }
            catch (Exception ex)
            {
                throw new TaskCanceledException($"{ex.Message} at {ex.StackTrace}");
            }
        }
    }
}
