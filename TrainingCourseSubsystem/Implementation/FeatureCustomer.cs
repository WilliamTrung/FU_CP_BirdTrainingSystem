using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
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
        public async Task<IEnumerable<TrainingCourseModel>> GetTrainingCourse()
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get();
            var models = _mapper.Map<IEnumerable<TrainingCourseModel>>(entities);
            return models;
        }

        public async Task<TrainingCourseModel> GetTrainingCourseById(int trainingCourseId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId);
            var models = _mapper.Map<TrainingCourseModel>(entities);
            return models;
        }

        public async Task RegisterBird(BirdModel bird)
        {
            if (bird == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Bird>(bird);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdRepository.Add(entity);
        }

        public async Task UpdateBirdProfile(BirdModel bird)
        {
            if (bird == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<Bird>(bird);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdRepository.Update(entity);
        }

        public async Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            if (birdTrainingCourseRegister == null)
                throw new Exception("Client send null model.");
            var entity = _mapper.Map<BirdTrainingCourse>(birdTrainingCourseRegister);
            if (entity == null)
            {
                throw new Exception("Mapping failed between " + nameof(BirdTrainingCourseRegister) + " and " + nameof(BirdTrainingCourse));
            }
            else
            {
                await _unitOfWork.BirdTrainingCourseRepository.Add(entity);
            }
        }

        public async Task<IEnumerable<TrainingCourseModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.BirdSpeciesId == birdSpeciesId);
            var models = _mapper.Map<IEnumerable<TrainingCourseModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdModel>> GetBirdByCustomerId(int customerId)
        {
            var entities = await _unitOfWork.BirdRepository.GetFirst(e => e.CustomerId == customerId);
            var models = _mapper.Map<IEnumerable<BirdModel>>(entities);
            return models;
        }
    }
}