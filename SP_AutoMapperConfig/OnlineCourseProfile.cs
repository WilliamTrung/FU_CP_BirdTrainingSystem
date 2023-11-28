using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.Enum.OnlineCourse.Customer.Lesson;
using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Certificate;
using Models.ServiceModels.OnlineCourseModels.Operation;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using SP_Extension;
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
            Map_OnlineCourse_OnlineCourseAdminViewModel();
            Map_OnlineCourseCertificateAddModel_Certificate();
            Map_CustomerCertificateDetail_OnlineCourseCertificateModel();
        }
        private void Map_CustomerCertificateDetail_OnlineCourseCertificateModel()
        {
            CreateMap<CustomerCertificateDetail, OnlineCourseCertificateModel>()
                .AfterMap<MappingAction_CustomerCertificateDetail_OnlineCourseCertificate>();
        }
        private void Map_OnlineCourseCertificateAddModel_Certificate()
        {
            CreateMap<CertificateAddModel, Certificate>();
        }
        private void Map_OnlineCourse_OnlineCourseAdminViewModel()
        {
            CreateMap<OnlineCourse, OnlineCourseAdminViewModel>();                
        }
        private void Map_Lesson_OnlineCourseLessonViewModel()
        {
            CreateMap<Lesson, OnlineCourseLessonViewModel>()
                .ForMember(m => m.Status, opt => opt.MapFrom<Map_Lesson_LessonViewModel_Resolver>());
        }
        private void Map_Section_OnlineCourseSectionViewModel()
        {
            CreateMap<Section, OnlineCourseSectionViewModel>()
                .ForMember(m => m.Status, opt => opt.MapFrom<Map_Section_SectionViewModel_Resolver>());
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
            CreateMap<OnlineCourseSectionAddModel, Section>()
                .ForMember(c => c.OnlineCourseId, opt => opt.MapFrom(m => m.CourseId));
        }
        private void Map_OnlineCourseLessonAddModel_Lesson()
        {
            CreateMap<OnlineCourseLessonAddModel, Lesson>()
                .ForMember(c => c.SectionId, opt => opt.MapFrom(m=>m.SectionId));
        }

        public class Map_Lesson_LessonViewModel_Resolver : IValueResolver<Lesson, OnlineCourseLessonViewModel, Models.Enum.OnlineCourse.Customer.Lesson.Status?>
        {
            public Status? Resolve(Lesson source, OnlineCourseLessonViewModel destination, Status? destMember, ResolutionContext context)
            {
                if (source.CustomerLessonDetails != null && source.CustomerLessonDetails.FirstOrDefault() != null)
                {
                    var customerLesson = source.CustomerLessonDetails.FirstOrDefault();
                    if (customerLesson.IsComplete == null)
                    {
                        return null;
                    }
                    else
                    {
                        var status = customerLesson.IsComplete.Value ? 1 : 0;
                        return (Models.Enum.OnlineCourse.Customer.Lesson.Status?)status;
                    }
                }
                return null;
            }
        }
        public class Map_Section_SectionViewModel_Resolver : IValueResolver<Section, OnlineCourseSectionViewModel, Models.Enum.OnlineCourse.Customer.Section.Status?>
        {
            public Models.Enum.OnlineCourse.Customer.Section.Status? Resolve(Section source, OnlineCourseSectionViewModel destination, Models.Enum.OnlineCourse.Customer.Section.Status? destMember, ResolutionContext context)
            {
                if (source.CustomerSectionDetails != null && source.CustomerSectionDetails.FirstOrDefault() != null)
                {
                    var customerSection = source.CustomerSectionDetails.FirstOrDefault();
                    if (customerSection.IsComplete == null)
                    {
                        return null;
                    }
                    else
                    {
                        var status = customerSection.IsComplete.Value ? 1 : 0;
                        return (Models.Enum.OnlineCourse.Customer.Section.Status?)status;
                    }
                }
                return null;
            }
        }
        public class MappingAction_CustomerCertificateDetail_OnlineCourseCertificate : IMappingAction<CustomerCertificateDetail, OnlineCourseCertificateModel>
        {
            public void Process(CustomerCertificateDetail source, OnlineCourseCertificateModel destination, ResolutionContext context)
            {
                destination.Picture = null;
                destination.ReceivedDate = source.ReceiveDate.Value.ToDateOnly();
                destination.Title = source.Certificate.Title;
                destination.Description = source.Certificate.ShortDescrption;
                destination.BirdCenterName = source.Certificate.BirdCenterName;
                destination.CustomerName = source.Customer.User.Name;
                destination.OnlineCourseId = source.Certificate.OnlineCourseId;
            }
        }
    }
}
