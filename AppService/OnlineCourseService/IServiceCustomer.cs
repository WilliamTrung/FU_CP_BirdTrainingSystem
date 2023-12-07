using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Certificate;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService
{
    public interface IServiceCustomer : IServiceAll
    {
        Task<IEnumerable<OnlineCourseModel>> GetCourses(int customerId);
        Task<OnlineCourseModel> GetCourseById(int customerId, int courseId);
        Task<BillingModel> GetBillingInformation(int customerId, int courseId);
        Task EnrollCourse(int customerId, int courseId, string paymentCode);
        Task<IEnumerable<OnlineCourseModel>> GetEnrolledCourses(int customerId);
        Task CheckCompleteLesson(int customerId, int lessonId);
        Task CheckCompleteSection(int customerId, int sectionId);
        Task CheckCompleteCourse(int customerId, int courseId);
        Task<IEnumerable<OnlineCourseModel>> GetCompletedCourses(int customerId);
        Task<OnlineCourseCertificateModel> GetCourseCertificate(int customerId, int courseId);
        Task<IEnumerable<OnlineCourseCertificateModel>> GetCertificates(int customerId);
        Task<Models.Enum.OnlineCourse.Customer.OnlineCourse.Status> CheckEnrolledCourse(int customerId, int courseId);
        Task DoFeedback(int customerId, FeedbackOnlineCourseCustomerAddModel feedback);
        Task<FeedbackOnlineCourseCustomerViewModel> GetFeedback(int customerId, int courseId);  


    }
}
