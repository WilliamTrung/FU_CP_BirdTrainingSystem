using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.OnlineCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCourseSubsystem.Implementation
{
    public class FeatureAll : IFeatureAll
    {
        internal readonly IUnitOfWork _unitOfWork;
        internal readonly IMapper _mapper;

        public FeatureAll (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<OnlineCourseModel>> GetCourses()
        {
            var entities = await _unitOfWork.OnlineCourseRepository.Get(expression: null);
            var models = _mapper.Map<List<OnlineCourseModel>>(entities);
            return models;  
        }

        public virtual async Task<OnlineCourseModel> GetCourseById(int id)
        {
            var entity = await _unitOfWork.OnlineCourseRepository.GetFirst(e => e.Id == id);
            if(entity == null)
            {
                throw new KeyNotFoundException("This course is not found!");
            }
            var model = _mapper.Map<OnlineCourseModel>(entity);
            return model;
        }
    }
}
