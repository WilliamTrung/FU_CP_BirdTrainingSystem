using AutoMapper;
using Models.Entities;
using Models.ServiceModels.WorkshopModels.Feedback;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class FeedbackWorkshopProfile : Profile
    {
        public FeedbackWorkshopProfile()
        {
        }
        private void Map_Feedback_FeedbackWorkshopCustomerViewModel()
        {
            CreateMap<Feedback, FeedbackWorkshopCustomerViewModel>()
                .AfterMap<MappingAction_Feedback_FeedbackWorkshopCustomerViewModel>();
        }

    }
    public class MappingAction_Feedback_FeedbackWorkshopCustomerViewModel : IMappingAction<Feedback, FeedbackWorkshopCustomerViewModel>
    {
        public void Process(Feedback source, FeedbackWorkshopCustomerViewModel destination, ResolutionContext context)
        {
            destination.Avatar = source.Customer.User.Avatar;
            destination.Membership = source.Customer.MembershipRank.Name;
            destination.Name = source.Customer.User.Name;
            destination.Feedback = source.FeedbackDetail;
            destination.Rating = source.Rating;
        }
    }
}
