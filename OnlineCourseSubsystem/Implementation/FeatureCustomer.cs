using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Certificate;
using Models.ServiceModels.OnlineCourseModels.Feedback;
using Models.ServiceModels.OnlineCourseModels.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem.Implementation
{
    public class FeatureCustomer : FeatureAll, IFeatureCustomer
    {
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task CheckCompleteCourse(int customerId, int courseId)
        {
            var entity = await _unitOfWork.CustomerOnlineCourseDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                            && c.OnlineCourseId == courseId
                                                                                            , nameof(CustomerOnlineCourseDetail.OnlineCourse)
                                                                                            , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}"
                                                                                            , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}.{nameof(Section.CustomerSectionDetails)}");
            if (entity == null)
            {
                throw new KeyNotFoundException("Customer has not enrolled to course!");
            }
            foreach (var section in entity.OnlineCourse.Sections)
            {
                var enrolled = section.CustomerSectionDetails.First(c => c.CustomerId == customerId && c.SectionId == section.Id);
                if(!enrolled.IsComplete.HasValue)
                {
                    throw new InvalidDataException("Error check section completion status");
                }
                if (!enrolled.IsComplete.Value)
                {
                    throw new InvalidOperationException("Customer must complete all sections!");
                }                
            }
            entity.Status = (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Completed;
            await _unitOfWork.CustomerOnlineCourseDetailRepository.Update(entity);
        }

        public async Task CheckCompleteLesson(int customerId, int lessionId)
        {
            var entity = await _unitOfWork.CustomerLessonDetailRepository.GetFirst(c => c.CustomerId== customerId 
                                                                                    && c.LessionId == lessionId
                                                                                     , nameof(CustomerLessonDetail.Lession));
            if(entity == null)
            {
                throw new KeyNotFoundException("Customer has not enrolled to course!");
            }
            entity.IsComplete = true;
            await _unitOfWork.CustomerLessonDetailRepository.Update(entity);

            var sectionId = entity.Lession.SectionId;
            var entities = await _unitOfWork.CustomerLessonDetailRepository.Get(c => c.CustomerId == customerId 
                                                                                    && c.Lession.SectionId == sectionId);
            bool isCompleteAll = true;
            foreach (var item in entities)
            {
                if(item.IsComplete == false)
                {
                    isCompleteAll = false;
                    break;
                }
            }
            if(isCompleteAll)
            {
                await CheckCompleteSection(customerId, sectionId);
            }
        }

        public async Task CheckCompleteSection(int customerId, int sectionId)
        {
            var entity = await _unitOfWork.CustomerSectionDetailRepository.GetFirst(c => c.CustomerId == customerId 
                                                                                        && c.SectionId == sectionId
                                                                                        , nameof(CustomerSectionDetail.Section)
                                                                                        , $"{nameof(CustomerSectionDetail.Section)}.{nameof(Section.Lessons)}"
                                                                                        , $"{nameof(CustomerSectionDetail.Section)}.{nameof(Section.Lessons)}.{nameof(Lesson.CustomerLessonDetails)}");
            if(entity == null)
            {
                throw new KeyNotFoundException("Customer has not enrolled to course!");
            }
            //force check complete for lessons
            foreach (var lesson in entity.Section.Lessons)
            {
                var enrolled = lesson.CustomerLessonDetails.First(c => c.CustomerId == customerId && c.LessionId == lesson.Id);
                enrolled.IsComplete = true;
            }
            entity.IsComplete = true;
            await _unitOfWork.CustomerSectionDetailRepository.Update(entity);

            var courseId = entity.Section.OnlineCourseId;
            var entities = await _unitOfWork.CustomerSectionDetailRepository.Get(c => c.CustomerId == customerId
                                                                                    && c.Section.OnlineCourseId == courseId);
            bool isCompleteAll = true;
            foreach (var item in entities)
            {
                if (item.IsComplete == false)
                {
                    isCompleteAll = false;
                    break;
                }
            }
            if (isCompleteAll)
            {
                await CheckCompleteCourse(customerId, courseId);
            }
        }

        public async Task<Models.Enum.OnlineCourse.Customer.OnlineCourse.Status> CheckEnrolledCourse(int customerId, int courseId)
        {
            var entity = await _unitOfWork.CustomerOnlineCourseDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                          && c.OnlineCourseId == courseId);
            if (entity == null)
            {
                return Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Unenrolled;
            } else
            {
                return (Models.Enum.OnlineCourse.Customer.OnlineCourse.Status)entity.Status;
            }            
        }

        public Task DoFeedback(int customerId, FeedbackOnlineCourseCustomerAddModel model)
        {
            throw new NotImplementedException();
        }

        public async Task EnrollCourse(int customerId, BillingModel billing)
        {
            var customerCourse = new CustomerOnlineCourseDetail()
            {
                CustomerId = customerId,
                OnlineCourseId = billing.CourseId,
                DiscountedPrice = billing.DiscountedPrice,
                Price = billing.CoursePrice,
                Status = (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Enrolled
            };
            await _unitOfWork.CustomerOnlineCourseDetailRepository.Add(customerCourse);
            var course = await _unitOfWork.OnlineCourseRepository.GetFirst(c => c.Id == billing.CourseId
                                                                            , nameof(OnlineCourse.Sections)
                                                                            , $"{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}"
                                                                            , $"{nameof(OnlineCourse.Sections)}.{nameof(Section.CustomerSectionDetails)}"
                                                                            , $"{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}.{nameof(Lesson.CustomerLessonDetails)}");
            //add enrolled status to each section and lesson
            foreach (var section in course.Sections)
            {
                var enrolledSection = new CustomerSectionDetail()
                {
                    CustomerId = customerId,
                    SectionId = section.Id,
                    IsComplete = false,
                };
                section.CustomerSectionDetails.Add(enrolledSection);
                foreach (var lesson in section.Lessons)
                {
                    var enrolledLesson = new CustomerLessonDetail()
                    {
                        CustomerId = customerId,
                        LessionId = lesson.Id,
                        IsComplete = false,
                    };
                    lesson.CustomerLessonDetails.Add(enrolledLesson);
                }
            }
            await _unitOfWork.OnlineCourseRepository.Update(course);   
            await GenerateCertificateOnEnroll(customerId, billing.CourseId);
        }



        public async Task<PreBillingModel> GetPreBillingInformation(int customerId, int courseId)
        {
            var customer = await _unitOfWork.CustomerRepository.GetFirst(c => c.Id == customerId, nameof(Customer.MembershipRank));
            if(customer == null)
            {
                throw new KeyNotFoundException("Customer is not found!");
            }
            var course = await _unitOfWork.OnlineCourseRepository.GetFirst(c => c.Id == courseId);
            if(course == null)
            {
                throw new KeyNotFoundException("Course is not found!");
            }
#pragma warning disable CS8629 // Nullable value type may be null.
#pragma warning disable CS8601 // Possible null reference assignment.
            var preBillingModel = new PreBillingModel()
            {
                CoursePrice = course.Price.Value,
                DiscountPercent = customer.MembershipRank.Discount.Value,
                MembershipName = customer.MembershipRank.Name
            };
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8629 // Nullable value type may be null.
            return preBillingModel;
        }



        public async Task<IEnumerable<OnlineCourseModel>> GetEnrolledCourses(int customerId)
        {
            var entities = await _unitOfWork.OnlineCourseRepository.Get(c => c.CustomerOnlineCourseDetails.Any(c => c.CustomerId == customerId), nameof(OnlineCourse.CustomerOnlineCourseDetails));
            var models = _mapper.Map<List<OnlineCourseModel>>(entities);
            return models;
        }

        public Task<FeedbackOnlineCourseCustomerViewModel?> GetFeedback(int customerId, int workshopId)
        {
            throw new NotImplementedException();
        }

        public async Task<OnlineCourseLessonViewModel> GetLessionByLessonId(int customerId, int lessonId)
        {
            var lesson = await _unitOfWork.LessonRepository.GetFirst(c => c.Id == lessonId
                                                                        && c.CustomerLessonDetails.Any(e => e.CustomerId == customerId)
                                                                        , nameof(Lesson.CustomerLessonDetails));
            var model = _mapper.Map<OnlineCourseLessonViewModel>(lesson);
            return model;
        }

        public async Task<IEnumerable<OnlineCourseLessonViewModel>> GetLessonsBySection(int customerId, int sectionId)
        {
            var section = await _unitOfWork.SectionRepository.GetFirst(c => c.Id == sectionId
                                                                         && c.CustomerSectionDetails.Any(e => e.CustomerId == customerId)
                                                                         , nameof(Section.CustomerSectionDetails)
                                                                         , nameof(Section.Lessons));            
            var models = _mapper.Map<List<OnlineCourseLessonViewModel>>(section.Lessons);
            return models;
        }

        public async Task<IEnumerable<OnlineCourseSectionViewModel>> GetSections(int customerId, int courseId)
        {
            var course = await _unitOfWork.CustomerOnlineCourseDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                        && c.OnlineCourseId == courseId
                                                                                        , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}");
            var models = _mapper.Map<List<OnlineCourseSectionViewModel>>(course.OnlineCourse.Sections);
            return models;
        }
        public async Task GenerateCertificateOnEnroll(int customerId, int courseId)
        {
            var course = await _unitOfWork.OnlineCourseRepository.GetFirst(c => c.Id == courseId, nameof(OnlineCourse.Certificates));
            if(course == null)
            {
                throw new KeyNotFoundException("Course does not exist!");
            }
            var cert = course.Certificates.First(x => x.OnlineCourseId == courseId);
            var customerCertDetail = new CustomerCertificateDetail()
            {
                CustomerId = customerId,
                CertificateId = cert.Id,                
            };
            await _unitOfWork.CustomerCertificateDetailRepository.Add(customerCertDetail);
        }
        public async Task<OnlineCourseCertificateModel> GetCertificateModel(int customerId, int courseId)
        {
            var cert = await _unitOfWork.CustomerCertificateDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                        && c.Certificate.OnlineCourseId == courseId
                                                                                        , nameof(CustomerCertificateDetail.Certificate)
                                                                                        , $"{nameof(CustomerCertificateDetail.Customer)}.{nameof(Customer.User)}");
            if(cert == null)
            {
                throw new InvalidOperationException("Customer has not enrolled to course!");
            }
            var progressStatus = await _unitOfWork.CustomerOnlineCourseDetailRepository.GetFirst(c => c.CustomerId == customerId && c.OnlineCourseId == courseId);
            if(progressStatus.Status != (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Completed)
            {
                throw new InvalidOperationException("Customer has not completed the course!");
            }
            var model = _mapper.Map<OnlineCourseCertificateModel>(cert);
            return model;
        }

        public async Task<IEnumerable<OnlineCourseCertificateModel>> GetCertificates(int customerId)
        {
            var certs = await _unitOfWork.CustomerCertificateDetailRepository.Get(c => c.CustomerId == customerId
                                                                                       , nameof(CustomerCertificateDetail.Certificate)
                                                                                       , $"{nameof(CustomerCertificateDetail.Customer)}.{nameof(Customer.User)}"
                                                                                       , $"{nameof(CustomerCertificateDetail.Certificate)}.{nameof(Certificate.OnlineCourse)}"
                                                                                       , $"{nameof(CustomerCertificateDetail.Certificate)}.{nameof(Certificate.OnlineCourse)}.{nameof(OnlineCourse.CustomerOnlineCourseDetails)}");
            certs = certs.Where(c => c.Certificate.OnlineCourse.CustomerOnlineCourseDetails.Any(e => e.Status == (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Completed));
            var models = _mapper.Map<List<OnlineCourseCertificateModel>>(certs);
            return models;
        }

        public async Task<IEnumerable<OnlineCourseModel>> GetCompletedCourse(int customerId)
        {
            var completedEnrolled = await _unitOfWork.CustomerOnlineCourseDetailRepository.Get(c => c.CustomerId == customerId
                                                                                                && c.Status == (int)Models.Enum.OnlineCourse.Customer.OnlineCourse.Status.Completed,
                                                                                                nameof(CustomerOnlineCourseDetail.OnlineCourse));
            var models = _mapper.Map<List<OnlineCourseModel>>(completedEnrolled.Select(e => e.OnlineCourse));
            return models;
        }
        public async Task<OnlineCourseModel> GetCourseById(int customerId, int courseId)
        {
            var courseRegistered = await _unitOfWork.CustomerOnlineCourseDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                            && c.OnlineCourseId == courseId
                                                                                            , nameof(CustomerOnlineCourseDetail.OnlineCourse)
                                                                                            , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}"
                                                                                            , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}.{nameof(Section.CustomerSectionDetails)}"
                                                                                            , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}"
                                                                                            , $"{nameof(CustomerOnlineCourseDetail.OnlineCourse)}.{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}.{nameof(Lesson.CustomerLessonDetails)}");
            if(courseRegistered == null )
            {
                //throw new InvalidOperationException("Customer has not enrolled to course!");
                return await GetCourseById(courseId);
            }
            foreach (var section in courseRegistered.OnlineCourse.Sections)
            {
                section.CustomerSectionDetails = section.CustomerSectionDetails.Where(c => c.CustomerId == customerId).ToList();
                foreach (var lesson in section.Lessons)
                {
                    lesson.CustomerLessonDetails = lesson.CustomerLessonDetails.Where(c => c.CustomerId == customerId).ToList();
                }
            }
            var model = _mapper.Map<OnlineCourseModel>(courseRegistered.OnlineCourse);
            return model;
        }

        public async Task<Models.Enum.OnlineCourse.Customer.Lesson.Status> CheckStatusLesson(int customerId, int lessonId)
        {
            var entity = await _unitOfWork.CustomerLessonDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                    && c.LessionId == lessonId);
            if(entity == null)
            {
                throw new KeyNotFoundException("Customer has not enrolled to course!");
            }
            if(entity.IsComplete == null)
            {
                throw new Exception("An error has occured!");
            }
            int result = entity.IsComplete.Value ? 1 : 0;
            return (Models.Enum.OnlineCourse.Customer.Lesson.Status)result;
        }

        public async Task<Models.Enum.OnlineCourse.Customer.Section.Status> CheckStatusSection(int customerId, int sectionId)
        {
            var entity = await _unitOfWork.CustomerSectionDetailRepository.GetFirst(c => c.CustomerId == customerId
                                                                                   && c.SectionId == sectionId);
            if (entity == null)
            {
                throw new KeyNotFoundException("Customer has not enrolled to course!");
            }
            if (entity.IsComplete == null)
            {
                throw new Exception("An error has occured!");
            }
            int result = entity.IsComplete.Value ? 1 : 0;
            return (Models.Enum.OnlineCourse.Customer.Section.Status)result;
        }
    }
}
