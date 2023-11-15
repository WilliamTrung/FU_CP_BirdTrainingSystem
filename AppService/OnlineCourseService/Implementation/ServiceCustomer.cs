using GoogleApi.Entities.Maps.StreetView.Request.Enums;
using Models.Enum.OnlineCourse.Customer.OnlineCourse;
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
        public ServiceCustomer (IOnlineCourseFeature onlineCourse, IFeatureTransaction transaction) : base (onlineCourse) 
        { 
            _transaction = transaction;
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

        public async Task EnrollCourse(int customerId, BillingModel billing)
        {
            if (await _onlineCourse.Customer.CheckEnrolledCourse(customerId, billing.CourseId) != Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Unenrolled)
            {
                throw new InvalidOperationException("Customer has enrolled to course!");
            }
            await _onlineCourse.Customer.EnrollCourse(customerId, billing);
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
                CourseId = courseId,
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
