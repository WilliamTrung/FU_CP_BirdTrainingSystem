using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureCustomer : FeatureUser, IFeatureCustomer
    {
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<IEnumerable<TrainingCourse>> GetTrainingCourse()
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get();
            var models = _mapper.Map<IEnumerable<Models.ServiceModels.TrainingCourseModels.TrainingCourse>>(entities);
            return models;
        }

        public async Task<TrainingCourse> GetTrainingCourseById(int trainingCourseId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId);
            var models = _mapper.Map<Models.ServiceModels.TrainingCourseModels.TrainingCourse>(entities);
            return models;
        }

        public async Task RegisterBird(Bird bird)
        {
            if(bird == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.Bird>(bird);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdRepository.Add(entity);
        }

        public async Task UpdateBirdProfile(Bird bird)
        {
            if (bird == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Models.Entities.Bird>(bird);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdRepository.Update(entity);
        }
    }
}
