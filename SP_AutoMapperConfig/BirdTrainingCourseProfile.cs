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
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.BirdId))
                .ForMember(m => m.TotalSlot, opt => opt.MapFrom(e => e.TrainingCourseId))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status))
                .ForMember(m => m.TrainingCourseTitle, opt => {
                    opt.PreCondition(e => e.TrainingCourse != null);
                    opt.MapFrom(e => e.TrainingCourse.Title);
                })
                .ForMember(m => m.TrainingCoursePicture, opt => {
                    opt.PreCondition(e => e.TrainingCourse != null);
                    opt.MapFrom(e => e.TrainingCourse.Picture);
                });
        }
        private void Map_BirdTrainingCourse_BirdTrainingCourseListView()
        {
            CreateMap<BirdTrainingCourse, BirdTrainingCourseListView>()
                .ForMember(m => m.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(m => m.TrainingCourseId, opt => opt.MapFrom(e => e.TrainingCourseId))
                .ForMember(m => m.BirdId, opt => opt.MapFrom(e => e.BirdId))
                .ForMember(m => m.BirdName, opt => {
                    opt.PreCondition(e => e.Bird != null);
                    opt.MapFrom(e => e.Bird.Name);
                })
                .ForMember(m => m.CustomerId, opt => opt.MapFrom(e => e.CustomerId))
                .ForMember(m => m.CustomerName, opt => {
                    opt.PreCondition(e => e.Customer != null);
                    opt.PreCondition(e => e.Customer.User != null);
                    opt.MapFrom(e => e.Customer.User.Name);
                }).ForMember(m => m.TrainingCourseTitle, opt => {
                    opt.PreCondition(e => e.TrainingCourse != null);
                    opt.MapFrom(e => e.TrainingCourse.Title);
                })
                .ForMember(m => m.RegisteredDate, opt => opt.MapFrom(e => e.RegisteredDate))
                .ForMember(m => m.Status, opt => opt.MapFrom(e => e.Status));
        }
    }
}