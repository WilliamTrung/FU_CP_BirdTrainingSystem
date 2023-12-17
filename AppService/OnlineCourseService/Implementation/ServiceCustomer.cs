using ApplicationService.MailSettings;
using GoogleApi.Entities.Maps.StreetView.Request.Enums;
using Models.Enum.OnlineCourse.Customer.OnlineCourse;
using Models.ServiceModels;
using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Certificate;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;
using OnlineCourseSubsystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionSubsystem;

namespace AppService.OnlineCourseService.Implementation
{
    public class ServiceCustomer : ServiceAll, IServiceCustomer
    {
        private readonly IFeatureTransaction _transaction;
        private readonly IMailService _mailService;
        public ServiceCustomer (IOnlineCourseFeature onlineCourse, IFeatureTransaction transaction, IMailService mailService) : base (onlineCourse) 
        { 
            _transaction = transaction;
            _mailService = mailService;
        }

        public async Task CheckCompleteCourse(int customerId, int courseId)
        {
            await _onlineCourse.Customer.CheckCompleteCourse(customerId, courseId);
        }

        public async Task CheckCompleteLesson(int customerId, int lessonId)
        {
            await _onlineCourse.Customer.CheckCompleteLesson(customerId, lessonId);
        }

        public async Task CheckCompleteSection(int customerId, int sectionId)
        {
            await _onlineCourse.Customer.CheckCompleteSection(customerId, sectionId);
        }

        public async Task<Status> CheckEnrolledCourse(int customerId, int courseId)
        {
            var result = await _onlineCourse.Customer.CheckEnrolledCourse(customerId, courseId);
            return result;
        }

        public Task DoFeedback(int customerId, FeedbackOnlineCourseCustomerAddModel feedback)
        {
            throw new NotImplementedException();
        }

        public async Task EnrollCourse(int customerId, int courseId, string paymentCode)
        {
            if (await _onlineCourse.Customer.CheckEnrolledCourse(customerId, courseId) != Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Unenrolled)
            {
                throw new InvalidOperationException("Customer has enrolled to course!");
            }
            var billing = await GetBillingInformation(customerId, courseId);
            string formattedDateTime = DateTime.UtcNow.AddHours(7).ToString("ddMMMyyyyhhmm");
            var transactionAddModel = new TransactionAddModel()
            {
                CustomerId = customerId,
                EntityId = courseId,
                EntityTypeId = (int)Models.Enum.EntityType.OnlineCourse,
                PaymentCode = paymentCode,
                Detail = $"{paymentCode}:{customerId}:{billing.Email}-enroll online course {courseId}:{billing.CourseTitle}-at:{formattedDateTime}",
                Status = (int)Models.Enum.Transaction.Status.Paid,
                Title = "Online course enrolled",
                TotalPayment = billing.TotalPrice,
            };
            var transaction = await _transaction.AddTransaction(transactionAddModel);

            var mailContent = new MailContent
            {
                Subject = "Payment information for online course purchasing",
                HtmlMessage = $"<h3>You have purchased for online course: </h3><p>{billing.CourseTitle}</p><br/>" +
             $"<h3>Your payment code: </h3>{transaction.PaymentCode.Split("_secret")[0]}<br/>" +
             $"<h3>Original cost: </h3>{billing.CoursePrice} VND<br/>" +
             $"<h3>Discounted: </h3>{billing.DiscountedPrice} VND<br/>" +
             $"<h3>Actual Cost: </h3>{transaction.TotalPayment} VND<br/>" +
             $"<h3>At {transaction.PaymentDate}</h3><br/><h2>Please save this information for service convenience!</h2>"
            };
            Task t_sendMail = _mailService.SendEmailAsync(billing.Email, mailContent);
            Task t_enrollCourse =  _onlineCourse.Customer.EnrollCourse(customerId, billing);
            Task.WaitAll(t_sendMail, t_enrollCourse);
        }

        public async Task<BillingModel> GetBillingInformation(int customerId, int courseId)
        {
            if(await _onlineCourse.Customer.CheckEnrolledCourse(customerId, courseId) != Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Unenrolled)
            {
                throw new InvalidOperationException("Customer has enrolled to course!");
            }
            var preBillingInformation = await _onlineCourse.Customer.GetPreBillingInformation(customerId, courseId);
            var final = await _transaction.CalculateFinalPrice(customerId, preBillingInformation.CoursePrice);
            var FinalPrice = final.GetType().GetProperty("FinalPrice").GetValue(final, null);
            var DiscountedPrice = final.GetType().GetProperty("DiscountedPrice").GetValue(final, null);
            var billing = new BillingModel()
            {
                Email = preBillingInformation.Email,
                CourseId = courseId,
                CourseTitle = preBillingInformation.CourseTitle,
                CoursePrice = preBillingInformation.CoursePrice,
                DiscountRate = preBillingInformation.DiscountPercent,
                MembershipName = preBillingInformation.MembershipName,
                DiscountedPrice = DiscountedPrice,
                TotalPrice = FinalPrice,                
            };         
            return billing;
        }

        public async Task<IEnumerable<OnlineCourseCertificateModel>> GetCertificates(int customerId)
        {
            var result = await _onlineCourse.Customer.GetCertificates(customerId);
            return result;
        }

        public async Task<IEnumerable<OnlineCourseModel>> GetCompletedCourses(int customerId)
        {
            var result = await _onlineCourse.Customer.GetCompletedCourse(customerId);
            return result;
        }

        public async Task<OnlineCourseModel> GetCourseById(int customerId, int courseId)
        {
            var result = await _onlineCourse.Customer.GetCourseById(customerId, courseId);
            result.Status = await CheckEnrolledCourse(customerId, result.Id);
            return result;
        }

        public async Task<OnlineCourseCertificateModel> GetCourseCertificate(int customerId, int courseId)
        {
            var result = await _onlineCourse.Customer.GetCertificateModel(customerId, courseId);
            return result;
        }

        public async Task<IEnumerable<OnlineCourseModel>> GetCourses(int customerId)
        {
            var courses = await GetCourses();
            foreach (var course in courses)
            {
                course.Status = await CheckEnrolledCourse(customerId, course.Id);
            }
            return courses;
        }

        public async Task<IEnumerable<OnlineCourseModel>> GetEnrolledCourses(int customerId)
        {
            var result = await _onlineCourse.Customer.GetEnrolledCourses(customerId);
            foreach (var item in result)
            {
                item.Status = await CheckEnrolledCourse(customerId, item.Id);
            }
            return result;
        }

        public Task<FeedbackOnlineCourseCustomerViewModel> GetFeedback(int customerId, int courseId)
        {
            throw new NotImplementedException();
        }
    }
}
