using AppRepository.UnitOfWork;
using AutoMapper;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureManager : FeatureUser, IFeatureManager
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task ArchiveCourse(TrainingCourse trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.TrainingCourse>(trainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                //update status
            }
            await _unitOfWork.TrainingCourseRepository.Update(entity);
        }

        public async Task CreateCourse(TrainingCourse trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.TrainingCourse>(trainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.TrainingCourseRepository.Add(entity);
        }

        public async Task EditCourse(TrainingCourse trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.TrainingCourse>(trainingCourse);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.TrainingCourseRepository.Update(entity);
        }
    }
}
