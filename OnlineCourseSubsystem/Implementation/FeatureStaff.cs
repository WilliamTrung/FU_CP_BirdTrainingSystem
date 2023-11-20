using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.OnlineCourseModels;
using Models.ServiceModels.OnlineCourseModels.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem.Implementation
{
    public class FeatureStaff : FeatureAll, IFeatureStaff
    {
        public FeatureStaff(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public override async Task<OnlineCourseModel> GetCourseById(int courseId)
        {
            var entity = await _unitOfWork.OnlineCourseRepository.GetFirst(c => c.Id == courseId
                                                                                , nameof(OnlineCourse.Sections)
                                                                                , $"{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}");
            var model = _mapper.Map<OnlineCourseModel>(entity);
            return model;
        }

        public override async Task<IEnumerable<OnlineCourseModel>> GetCourses()
        {
            var entities = await _unitOfWork.OnlineCourseRepository.Get();
            var models = _mapper.Map<List<OnlineCourseModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<OnlineCourseAdminViewModel>> GetCoursesAdmin()
        {
            var entities = await _unitOfWork.OnlineCourseRepository.Get(expression: null
                                                                        , $"{nameof(OnlineCourse.Sections)}"
                                                                        , $"{nameof(OnlineCourse.Sections)}.{nameof(Section.Lessons)}");
            var models = _mapper.Map<List<OnlineCourseAdminViewModel>>(entities);
            return models;
        }

        public async Task<OnlineCourseLessonViewModel> GetLessonByLessonId(int lessonId)
        {
            var entity = await _unitOfWork.LessonRepository.GetFirst(c => c.Id == lessonId);
            var model = _mapper.Map<OnlineCourseLessonViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<OnlineCourseLessonViewModel>> GetLessonsBySection(int sectionId)
        {
            var entities = await _unitOfWork.LessonRepository.Get(c => c.SectionId == sectionId);
            var models = _mapper.Map<List<OnlineCourseLessonViewModel>>(entities);
            return models;
        }

        public async Task<OnlineCourseSectionViewModel> GetSectionById(int sectionId)
        {
            var entity = await _unitOfWork.SectionRepository.GetFirst(c => c.Id == sectionId);
            var model = _mapper.Map<OnlineCourseSectionViewModel>(entity);
            return model;
        }

        public async Task<IEnumerable<OnlineCourseSectionViewModel>> GetSectionsByCourseId(int courseId)
        {
            var entities = await _unitOfWork.SectionRepository.Get(c => c.OnlineCourseId == courseId);
            var model = _mapper.Map<List<OnlineCourseSectionViewModel>>(entities);
            return model;
        }
    }
}
