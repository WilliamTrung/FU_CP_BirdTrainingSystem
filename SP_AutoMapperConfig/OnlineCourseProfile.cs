using AutoMapper;
using Models.Entities;
using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class OnlineCourseProfile : Profile
    {
        public OnlineCourseProfile() 
        {
            Map_OnlineCourseAddModel_OnlineCourse();
            Map_OnlineCourse_OnlineCourseModel();
            Map_Lesson_OnlineCourseLessonViewModel();
            Map_Section_OnlineCourseSectionViewModel();
            Map_OnlineCourseSectionAddModel_Section();
            Map_OnlineCourseLessonAddModel_Lesson();
        }
        private void Map_Lesson_OnlineCourseLessonViewModel()
        {
            CreateMap<Lesson, OnlineCourseLessonViewModel>();
        }
        private void Map_Section_OnlineCourseSectionViewModel()
        {
            CreateMap<Section, OnlineCourseSectionViewModel>();
        }
        private void Map_OnlineCourse_OnlineCourseModel()
        {
            CreateMap<OnlineCourse, OnlineCourseModel>();
        }
        private void Map_OnlineCourseAddModel_OnlineCourse()
        {
            CreateMap<OnlineCourseAddModel, OnlineCourse>()
                .ForMember(e => e.Id, opt => opt.Ignore())
                .ForMember(e => e.Status, opt => opt.MapFrom(v => Models.Enum.OnlineCourse.Status.INACTIVE));
                
        }
        private void Map_OnlineCourseSectionAddModel_Section()
        {
            CreateMap<OnlineCourseSectionAddModel, Section>();
        }
        private void Map_OnlineCourseLessonAddModel_Lesson()
        {
            CreateMap<OnlineCourseLessonAddModel, Lesson>();
        }
    }
}
