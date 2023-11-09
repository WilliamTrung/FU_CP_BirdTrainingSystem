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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FeatureAll (IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OnlineCourseModel>> GetListOnlineCourse()
        {
            var entities = await _unitOfWork.OnlineCourseRepository.Get(expression: null);
            var models = new List<OnlineCourseModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<OnlineCourseModel>(entity);
                models.Add(model);
            }

            return models;  
        }

        public async Task<OnlineCourseDetailViewModel> GetOnlineCourseById(int id)
        {
            var entites = await _unitOfWork.OnlineCourseRepository.GetFirst(x => x.Id == id);
            var model = _mapper.Map<OnlineCourseDetailViewModel>(entites);

            return model;
        }
    }
}
