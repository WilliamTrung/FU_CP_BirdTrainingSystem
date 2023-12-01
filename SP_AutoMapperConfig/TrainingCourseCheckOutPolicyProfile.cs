using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.TrainingCourseCheckOutPolicy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TrainingCourseCheckOutPolicyProfile : Profile
    {
        public TrainingCourseCheckOutPolicyProfile()
        {
            Map_TrainingCourseCheckOutPolicy_TrainingCourseCheckOutPolicyModel();
            Map_PolicyAddModel_TrainingCourseCheckOutPolicy();
            Map_PolicyModModel_TrainingCourseCheckOutPolicy();
        }

        private void Map_PolicyAddModel_TrainingCourseCheckOutPolicy()
        {
            CreateMap<PolicyAddModel, TrainingCourseCheckOutPolicy>()
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.ChargeRate, opt => opt.MapFrom(e => e.ChargeRate))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => (int)Models.Enum.TCCheckOutPolicy.Status.Active));
        }
        private void Map_PolicyModModel_TrainingCourseCheckOutPolicy()
        {
            CreateMap<PolicyModModel, TrainingCourseCheckOutPolicy>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(m => m.ChargeRate, opt => opt.MapFrom(e => e.ChargeRate))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => (int)Models.Enum.TCCheckOutPolicy.Status.Disable));
        }

        private void Map_TrainingCourseCheckOutPolicy_TrainingCourseCheckOutPolicyModel()
        {
            CreateMap<TrainingCourseCheckOutPolicy, TrainingCourseCheckOutPolicyModel>()
                .AfterMap<MapAction_TrainingCourseCheckOutPolicy_TrainingCourseCheckOutPolicyModel>();
        }
        public class MapAction_TrainingCourseCheckOutPolicy_TrainingCourseCheckOutPolicyModel : IMappingAction<TrainingCourseCheckOutPolicy, TrainingCourseCheckOutPolicyModel>
        {
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;
            public MapAction_TrainingCourseCheckOutPolicy_TrainingCourseCheckOutPolicyModel(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }
            public void Process(TrainingCourseCheckOutPolicy source, TrainingCourseCheckOutPolicyModel destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                destination.Name = source.Name;
                destination.ChargeRate = source.ChargeRate;
                destination.Status = (Models.Enum.TCCheckOutPolicy.Status)source.Status;
            }
        }
    }
}
