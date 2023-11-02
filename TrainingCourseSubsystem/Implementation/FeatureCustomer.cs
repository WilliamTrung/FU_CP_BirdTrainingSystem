using AppRepository.UnitOfWork;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels.Bird;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingProgress;
using Models.ServiceModels.TrainingCourseModels.BirdTrainingReport;
using Models.ServiceModels.TrainingCourseModels.TrainingCourse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureCustomer : FeatureAll, IFeatureCustomer
    {
        public FeatureCustomer(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }
        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourse()
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get(expression: null
                                                                         , nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            return models;
        }

        public async Task<TrainingCourseViewModel> GetTrainingCourseById(int trainingCourseId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId 
                                                                                 && e.Status == (int)Models.Enum.TrainingCourse.Status.Active
                                                                               , nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<TrainingCourseViewModel>(entities);
            return models;
        }

        public async Task RegisterBird(BirdAddModel bird)
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
            entity.Status = (int)Models.Enum.Bird.Status.Ready;
            await _unitOfWork.BirdRepository.Add(entity);
        }

        public async Task UpdateBirdProfile(BirdModifyModel bird)
        {
            if (bird == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _unitOfWork.BirdRepository.GetFirst(e => e.Id == bird.Id).Result;
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            //entity.CustomerId = bird.CustomerId;
            entity.BirdSpeciesId = bird.BirdSpeciesId;
            entity.Name = bird.Name;
            entity.Color = bird.Color;
            entity.Picture = bird.Picture;
            entity.Description = bird.Description;
            entity.IsDefault = bird.IsDefault;
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
                entity.LastestUpdate = DateTime.Now;
                entity.RegisteredDate= DateTime.Now;
                entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Registered;
                await _unitOfWork.BirdTrainingCourseRepository.Add(entity);
            }
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.GetFirst(e => e.BirdSpeciesId == birdSpeciesId
                                                                                 && e.Status == (int)Models.Enum.TrainingCourse.Status.Active
                                                                               , nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdViewModel>> GetBirdByCustomerId(int customerId)
        {
            var entities = await _unitOfWork.BirdRepository.GetFirst(e => e.CustomerId == customerId
                                                                     , nameof(Bird.BirdSpecies)
                                                                     , nameof(Bird.Customer)
                                                                     , $"{nameof(Bird.Customer)}.{nameof(Bird.Customer.User)}");
            var models = _mapper.Map<IEnumerable<BirdViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdTrainingCourseViewModel>> ViewRegisteredTrainingCourse(int birdId, int customerId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(expression:e => e.CustomerId == customerId && e.BirdId == birdId
                                                                                 && e.Status == (int)Models.Enum.TrainingCourse.Status.Active
                                                                                 , nameof(TrainingCourse));
            List<BirdTrainingCourseViewModel> models = new List<BirdTrainingCourseViewModel>();
            foreach(var entity in entities)
            {
                var model = _mapper.Map<BirdTrainingCourseViewModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public async Task<IEnumerable<BirdTrainingProgressViewModel>> ViewBirdTrainingCourseProgress(int birdTrainingCourseId)
        {
            var entities = await _unitOfWork.BirdTrainingProgressRepository.Get(expression: e => e.BirdTrainingCourseId == birdTrainingCourseId
                                                                                ,nameof(BirdTrainingProgress.Trainer)
                                                                                ,nameof(BirdTrainingProgress.TrainingCourseSkill)
                                                                                ,$"{nameof(BirdTrainingProgress.TrainingCourseSkill)}.{nameof(BirdTrainingProgress.TrainingCourseSkill.BirdSkill)}");
            List<BirdTrainingProgressViewModel> models = new List<BirdTrainingProgressViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<BirdTrainingProgressViewModel>(entity);
                models.Add(model);
            }
            return models;
        }

        public async Task<IEnumerable<BirdTrainingReportViewModel>> ViewBirdTrainingCourseReport(int birdTrainingProgressId)
        {
            var entities = await _unitOfWork.BirdTrainingReportRepository.Get(expression: e => e.BirdTrainingProgressId == birdTrainingProgressId
                                                                              , nameof(TrainerSlot));
            List<BirdTrainingReportViewModel> models = new List<BirdTrainingReportViewModel>();
            foreach (var entity in entities)
            {
                var model = _mapper.Map<BirdTrainingReportViewModel>(entity);
                models.Add(model);
            }
            return models;
        }
    }
}