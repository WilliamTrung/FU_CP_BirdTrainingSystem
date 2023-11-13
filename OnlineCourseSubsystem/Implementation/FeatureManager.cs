using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.Enum.OnlineCourse;
using Models.ServiceModels.OnlineCourseModels.Certificate;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem.Implementation
{
    public class FeatureManager : FeatureStaff, IFeatureManager
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task AddLesson(OnlineCourseLessonAddModel model)
        {
            var lesson = _mapper.Map<Lesson>(model);  
            await _unitOfWork.LessonRepository.Add(lesson);
        }

        public async Task AddSection(OnlineCourseSectionAddModel model)
        {
            var section = _mapper.Map<Section>(model);
            await _unitOfWork.SectionRepository.Add(section);
        }

        public async Task ChangeCourseStatus(int courseId, Status status)
        {
            var course = await _unitOfWork.OnlineCourseRepository.GetFirst(c => c.Id == courseId, nameof(OnlineCourse.CustomerOnlineCourseDetails)
                                                                                                , $"{nameof(OnlineCourse.Sections)}"
                                                                                                , $"{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}");
            if (course == null)
            {
                throw new KeyNotFoundException("Course is not found!");
            } else if (status == Models.Enum.OnlineCourse.Status.CANCELLED)
            {
                if(course.Status == (int)Models.Enum.OnlineCourse.Status.ACTIVE && course.CustomerOnlineCourseDetails.Count() > 0)
                {
                    throw new InvalidDataException("Cannot cancel this course due to customer activities!");
                }
            } else if(status == Models.Enum.OnlineCourse.Status.INACTIVE)
            {
                //nothing
            } else if(status == Models.Enum.OnlineCourse.Status.ACTIVE)
            {
                //check if there are sections and lessons 
                if(course.Sections.Count > 0)
                {
                    foreach (var section in course.Sections)
                    {
                        if(section.Lessons.Count < 0)
                        {
                            throw new InvalidOperationException("Lesson is not fulfilled!");
                        }
                    }
                } else
                {
                    throw new InvalidOperationException("Section is not fulfilled!");
                }
                
            }
            course.Status = (int)status;
            await _unitOfWork.OnlineCourseRepository.Update(course);
        }

        public async Task CreateOnlineCourse(OnlineCourseAddModel model)
        {
            var entity = _mapper.Map<OnlineCourse>(model);
            await _unitOfWork.OnlineCourseRepository.Add(entity);
            await GenerateCertificateOnCreateCourse(entity);
        }

        public async Task DeleteLesson(int lessonId)
        {
            var lesson = await _unitOfWork.LessonRepository.GetFirst(c => c.Id == lessonId, nameof(Lesson.CustomerLessonDetails));
            if(lesson.CustomerLessonDetails.Count > 0)
            {
                throw new InvalidOperationException("This course has operated with customer!");
            }
            await _unitOfWork.LessonRepository.Delete(lesson);
        }

        public async Task DeleteSection(int sectionId)
        {
            var section = await _unitOfWork.SectionRepository.GetFirst(c => c.Id == sectionId, nameof(Section.CustomerSectionDetails));
            if (section.CustomerSectionDetails.Count > 0)
            {
                throw new InvalidOperationException("This course has operated with customer!");
            }
            await _unitOfWork.SectionRepository.Delete(section);
        }

        public async Task ModifyLesson(OnlineCourseLessonModifyModel model)
        {
            Lesson? lesson = await _unitOfWork.LessonRepository.GetFirst(c => c.Id == model.Id);
            if(lesson == null) {
                throw new KeyNotFoundException("This lesson is not found!");
            }
            if(model.Detail != null)
            {
                lesson.Detail = model.Detail;
            }
            if(model.Description != null)
            {
                lesson.Description = model.Description;
            }
            if(model.Title != null)
            {
                lesson.Title = model.Title;
            }
            if(model.Video != null)
            {
                lesson.Video = model.Video;
            }
            await _unitOfWork.LessonRepository.Update(lesson);
        }

        public async Task ModifySection(OnlineCourseSectionModifyModel model)
        {
            Section? section = await _unitOfWork.SectionRepository.GetFirst(c => c.Id == model.Id);
            if(section == null)
            {
                throw new KeyNotFoundException("Section not found!");
            }
            section.Title = model.Title;
            await _unitOfWork.SectionRepository.Update(section);
        }
        private async Task GenerateCertificateOnCreateCourse(OnlineCourse course)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            var model = new CertificateAddModel()
            {
                OnlineCourseId = course.Id,
                ShortDescription = course.ShortDescription,
                Title = course.Title,
            };
#pragma warning restore CS8601 // Possible null reference assignment.
            var entity = _mapper.Map<Certificate>(model);
            await _unitOfWork.CertificateRepository.Add(entity);
        }
    }
}
