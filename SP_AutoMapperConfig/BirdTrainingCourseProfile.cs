﻿using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class BirdTrainingCourseProfile : Profile
    {
        public BirdTrainingCourseProfile()
        {
            Map_BirdTrainingCourse_BirdTrainingCourseRegister();
            Map_BirdTrainingCourse_BirdTrainingCourseViewModel();
            Map_BirdTrainingCourse_BirdTrainingCourseListView();
        }
        private void Map_BirdTrainingCourse_BirdTrainingCourseRegister()
        {
            CreateMap<BirdTrainingCourseRegister, BirdTrainingCourse>()
                .ForMember(m => m.BirdId, opt => opt.MapFrom(e => e.BirdId))
                .ForMember(m => m.TrainingCourseId, opt => opt.MapFrom(e => e.TrainingCourseId))
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(e => e.CustomerId))
                .ForMember(m => m.TotalPrice, opt => opt.MapFrom(e => e.TotalPrice));
            //.ForMember(m => m.DiscountedPrice, opt => opt.MapFrom(e => e.DiscountedPrice));
            //.ForMember(m => m.LastestUpdate, opt => opt.MapFrom(e => DateTime.Now))
            //.ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status))
            //.ForMember(m => m.Bird, opt => {
            //    opt.PreCondition(e => e.Bird != null);
            //    opt.MapFrom(e => e.Bird);
            //})
            //.ForMember(m => m.TrainingCourse, opt => {
            //    opt.PreCondition(e => e.TrainingCourse != null);
            //    opt.MapFrom(e => e.TrainingCourse);
            //});
        }
        private void Map_BirdTrainingCourse_BirdTrainingCourseViewModel()
        {
            CreateMap<BirdTrainingCourse, BirdTrainingCourseViewModel>()
                .AfterMap<MapAction_BirdTrainingCourse_BirdTrainingCourseViewModel>();
            //.ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
            //.ForMember(m => m.RegisteredDate, opt => opt.MapFrom(e => e.RegisteredDate))
            //.ForMember(m => m.StartTrainingDate, opt => opt.MapFrom(e => e.StartTrainingDate))
            //.ForMember(m => m.TotalSlot, opt => {
            //    opt.PreCondition(e => e.TrainingCourse != null);
            //    opt.MapFrom(e => e.TrainingCourse.TotalSlot);
            //})
            //.ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status))
            //.ForMember(m => m.TrainingCourseTitle, opt => {
            //    opt.PreCondition(e => e.TrainingCourse != null);
            //    opt.MapFrom(e => e.TrainingCourse.Title);
            //})
            //.ForMember(m => m.TrainingCoursePicture, opt => {
            //    opt.PreCondition(e => e.TrainingCourse != null);
            //    opt.MapFrom(e => e.TrainingCourse.Picture);
            //});
        }
        private void Map_BirdTrainingCourse_BirdTrainingCourseListView()
        {
            CreateMap<BirdTrainingCourse, BirdTrainingCourseListView>()
                .AfterMap<MapAction_BirdTrainingCourse_BirdTrainingCourseListView>();
            //.ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
            //.ForMember(m => m.TrainingCourseId, opt => opt.MapFrom(e => e.TrainingCourseId))
            //.ForMember(m => m.BirdId, opt => opt.MapFrom(e => e.BirdId))
            //.ForMember(m => m.BirdName, opt => {
            //    opt.PreCondition(e => e.Bird != null);
            //    opt.MapFrom(e => e.Bird.Name);
            //})
            //.ForMember(m => m.CustomerId, opt => opt.MapFrom(e => e.CustomerId))
            //.ForMember(m => m.CustomerName, opt => {
            //    opt.PreCondition(e => e.Customer != null);
            //    opt.PreCondition(e => e.Customer.User != null);
            //    opt.MapFrom(e => e.Customer.User.Name);
            //}).ForMember(m => m.TrainingCourseTitle, opt => {
            //    opt.PreCondition(e => e.TrainingCourse != null);
            //    opt.MapFrom(e => e.TrainingCourse.Title);
            //})
            //.ForMember(m => m.RegisteredDate, opt => opt.MapFrom(e => e.RegisteredDate))
            //.ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status));
        }

        public class MapAction_BirdTrainingCourse_BirdTrainingCourseViewModel : IMappingAction<BirdTrainingCourse, BirdTrainingCourseViewModel>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public MapAction_BirdTrainingCourse_BirdTrainingCourseViewModel(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public void Process(BirdTrainingCourse source, BirdTrainingCourseViewModel destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == source.TrainingCourseId).Result;
                if (trainingCourse != null)
                {
                    destination.TrainingCourseTitle = trainingCourse.Title;
                    destination.TrainingCoursePicture = trainingCourse.Picture;
                    destination.TotalSlot = trainingCourse.TotalSlot;
                }
                if (source.RegisteredDate != null)
                {
                    destination.RegisteredDate = source.RegisteredDate.Value.ToString("dd-MM-yyyy hh:mm:ss");
                }
                if (source.StartTrainingDate != null)
                {
                    destination.StartTrainingDate = source.StartTrainingDate.Value.ToString("dd-MM-yyyy hh:mm:ss");
                }
                if (source.TrainingDoneDate != null)
                {
                    destination.TrainingDoneDate = source.TrainingDoneDate.Value.ToString("dd-MM-yyyy hh:mm:ss");
                }
                if (source.TotalPrice != null)
                {
                    destination.Price = source.TotalPrice;
                }
                if (source.DiscountedPrice != null)
                {
                    destination.DiscountedPrice = source.DiscountedPrice;
                }
            }
        }

        public class MapAction_BirdTrainingCourse_BirdTrainingCourseListView : IMappingAction<BirdTrainingCourse, BirdTrainingCourseListView>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            public MapAction_BirdTrainingCourse_BirdTrainingCourseListView(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public void Process(BirdTrainingCourse source, BirdTrainingCourseListView destination, ResolutionContext context)
            {
                destination.Id = source.Id;
                var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == source.BirdId).Result;
                if (bird != null)
                {
                    destination.BirdId = bird.Id;
                    destination.BirdName = bird.Name ?? "";
                }
                var customer = _unitOfWork.CustomerRepository.GetFirst(e => e.Id == source.CustomerId
                                                                        , nameof(Customer.User)
                                                                        , nameof(Customer.MembershipRank)).Result;
                if (customer != null)
                {
                    destination.CustomerId = customer.Id;
                    destination.CustomerName = customer.User.Name ?? "";
                    destination.CustomerEmail = customer.User.Email;
                    if (customer.MembershipRank != null)
                    {
                        destination.MembershipRankId = customer.MembershipRank.Id;
                        destination.MembershipRank = customer.MembershipRank.Name;
                    }
                }
                var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == source.TrainingCourseId).Result;
                if (trainingCourse != null)
                {
                    destination.TrainingCourseTitle = trainingCourse.Title;
                    destination.TrainingCourseId = trainingCourse.Id;
                }
                if (source.RegisteredDate != null)
                {
                    destination.RegisteredDate = source.RegisteredDate.Value.ToString("dd-MM-yyyy");
                }
                if (source.StartTrainingDate != null)
                {
                    destination.StartTrainingDate = source.StartTrainingDate.Value.ToString("dd-MM-yyyy");
                }
                if (source.TrainingDoneDate != null)
                {
                    destination.TrainingDoneDate = source.TrainingDoneDate.Value.ToString("dd-MM-yyyy");
                }
                if (source.TotalPrice != null)
                {
                    destination.TotalPrice = source.TotalPrice;
                }
                if (source.TrainingCourseCheckOutPolicyId != null)
                {
                    destination.PricePolicyId = source.TrainingCourseCheckOutPolicyId;
                }
                if (source.DiscountedPrice != null)
                {
                    destination.DiscountedPrice = source.DiscountedPrice;
                    if(source.TrainingCourseCheckOutPolicyId != null)
                    {
                        var pricePolicy = _unitOfWork.TrainingCourseCheckOutPolicyRepository.GetFirst(e => 
                                                                                    e.Id == source.TrainingCourseCheckOutPolicyId).Result;
                        if (pricePolicy == null)
                        {
                            throw new InvalidOperationException("Can not found price policy.");
                        }
                        else
                        {
                            destination.ActualPrice = (source.DiscountedPrice * (decimal)pricePolicy.ChargeRate);
                        }
                    }
                    else
                    {
                        destination.ActualPrice = source.DiscountedPrice;
                    }
                }
            }
        }
    }
}