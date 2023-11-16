using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Certificate;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;
using Models.ServiceModels.WorkshopModels.Feedback;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem
{
    public interface IFeatureCustomer
    {
        Task EnrollCourse(int customerId, BillingModel billing);
        Task<IEnumerable<OnlineCourseSectionViewModel>> GetSections(int customerId, int courseId);
        Task<Models.Enum.OnlineCourse.Customer.OnlineCourse.Status> CheckEnrolledCourse(int customerId, int courseId);
        Task<Models.Enum.OnlineCourse.Customer.Lesson.Status> CheckStatusLesson(int customerId, int lessonId);
        Task<Models.Enum.OnlineCourse.Customer.Section.Status> CheckStatusSection(int customerId, int sectionId);
        Task<IEnumerable<OnlineCourseModel>> GetEnrolledCourses(int customerId);
        Task<IEnumerable<OnlineCourseLessonViewModel>> GetLessonsBySection(int customerId, int sectionId);
        Task<OnlineCourseLessonViewModel> GetLessionByLessonId(int customerId, int lessonId);
        Task CheckCompleteLesson(int customerId, int lessionId);
        Task CheckCompleteSection(int customerId, int sectionId);
        Task CheckCompleteCourse(int customerId, int courseId); 
        Task<PreBillingModel> GetPreBillingInformation(int customerId, int courseId);
        Task DoFeedback(int customerId, FeedbackOnlineCourseCustomerAddModel model);
        Task<FeedbackOnlineCourseCustomerViewModel?> GetFeedback(int customerId, int workshopId);
        Task GenerateCertificateOnEnroll(int customerId, int courseId);
        Task<IEnumerable<OnlineCourseModel>> GetCompletedCourse(int customerId);        
        Task<OnlineCourseCertificateModel> GetCertificateModel(int customerId, int courseId);
        Task<IEnumerable<OnlineCourseCertificateModel>> GetCertificates(int customerId);
        Task<OnlineCourseModel> GetCourseById(int customerId, int courseId);
    }
}
