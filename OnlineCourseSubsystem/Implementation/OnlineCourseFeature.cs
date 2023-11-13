using AppRepository.UnitOfWork;
using AutoMapper;
using AutoMapper.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem.Implementation
{
    public class OnlineCourseFeature : IOnlineCourseFeature
    {
        public OnlineCourseFeature(IFeatureManager managerFeature, IFeatureCustomer customerFeature, IFeatureStaff staffFeature, IFeatureAll allFeature)
        {
            Manager = managerFeature;
            Customer = customerFeature;
            Staff = staffFeature;
            All = allFeature;
        }
        public IFeatureManager Manager { get; private set; }
        public IFeatureCustomer Customer { get; private set; }

        public IFeatureStaff Staff { get; private set; } 

        public IFeatureAll All { get; private set; }
    }
}
