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
            var entities = await _unitOfWork.TrainingCourseRepository.Get(expression:e => e.Status == (int)Models.Enum.TrainingCourse.Status.Active
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
            entity.Name = bird.Name ?? entity.Name;
            entity.Color = bird.Color ?? entity.Color;
            entity.Picture = bird.Picture ?? entity.Picture;
            entity.Description = bird.Description ?? entity.Description;
            entity.IsDefault = bird.IsDefault ?? entity.IsDefault;
            await _unitOfWork.BirdRepository.Update(entity);
        }

        public async Task RegisterTrainingCourse(BirdTrainingCourseRegister birdTrainingCourseRegister)
        {
            if (birdTrainingCourseRegister == null)
                throw new Exception("Client send null model.");
            var bird = _unitOfWork.BirdRepository.GetFirst(e => e.Id == birdTrainingCourseRegister.BirdId).Result;
            var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == birdTrainingCourseRegister.TrainingCourseId).Result;
            if (trainingCourse != null && bird != null)
            {
                if(bird.BirdSpeciesId != trainingCourse.BirdSpeciesId)
                {
                    throw new Exception("Bird can not learn this course because of species difference.");
                }
            }
            var entity = _mapper.Map<BirdTrainingCourse>(birdTrainingCourseRegister);
            if (entity == null)
            {
                throw new Exception("Mapping failed between " + nameof(BirdTrainingCourseRegister) + " and " + nameof(BirdTrainingCourse));
            }
            else
            {
                entity.RegisteredDate= DateTime.Now;
                entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Registered;

                var customer = _unitOfWork.CustomerRepository.GetFirst(e => e.Id == entity.CustomerId
                                                                        ,nameof(Customer.MembershipRank)).Result;
                if (customer == null) throw new Exception(nameof(Customer) + " is not found.");
                else
                {
                    var discount = customer.MembershipRank.Discount.HasValue ? customer.MembershipRank.Discount.Value : 0;
                    var discountedPrice = entity.TotalPrice - entity.TotalPrice * (decimal)discount;
                    entity.DiscountedPrice = discountedPrice;
                }

                await _unitOfWork.BirdTrainingCourseRepository.Add(entity);
            }
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesId(int birdSpeciesId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get(e => e.BirdSpeciesId == birdSpeciesId
                                                                                 && e.Status == (int)Models.Enum.TrainingCourse.Status.Active
                                                                               , nameof(TrainingCourse.BirdSpecies));
            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdViewModel>> GetBirdByCustomerId(int customerId)
        {
            var entities = await _unitOfWork.BirdRepository.Get(e => e.CustomerId == customerId
                                                                     , nameof(Bird.BirdSpecies)
                                                                     , nameof(Bird.Customer)
                                                                     , $"{nameof(Bird.Customer)}.{nameof(Bird.Customer.User)}");
            var models = _mapper.Map<IEnumerable<BirdViewModel>>(entities);
            return models;
        }

        public async Task<IEnumerable<BirdTrainingCourseViewModel>> ViewRegisteredTrainingCourse(int birdId, int customerId)
        {
            var entities = await _unitOfWork.BirdTrainingCourseRepository.Get(expression:e => e.CustomerId == customerId && e.BirdId == birdId
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

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseByBirdSkillId(int birdSkillId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get(e => e.Status == (int)Models.Enum.TrainingCourse.Status.Active
                                                                               , nameof(TrainingCourse.BirdSpecies));
            var trainingSkill = _unitOfWork.TrainingCourseSkillRepository.Get(e => e.BirdSkillId == birdSkillId).Result.ToList();
            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            models = models.Where(e => trainingSkill.Any(m => m.TrainingCourseId == e.Id)).ToList();
            return models;
        }

        public async Task<IEnumerable<TrainingCourseViewModel>> GetTrainingCourseBySpeciesIdBirdSkillId(int birdSpeciesId, int birdSkillId)
        {
            var entities = await _unitOfWork.TrainingCourseRepository.Get(e => e.BirdSpeciesId == birdSpeciesId 
                                                                            && e.Status == (int)Models.Enum.TrainingCourse.Status.Active
                                                                               , nameof(TrainingCourse.BirdSpecies));

            var trainingSkill = _unitOfWork.TrainingCourseSkillRepository.Get(e => e.BirdSkillId == birdSkillId).Result.ToList();

            var models = _mapper.Map<IEnumerable<TrainingCourseViewModel>>(entities);
            models = models.Where(e => trainingSkill.Any(m => m.TrainingCourseId == e.Id)).ToList();
            return models;
        }
    }
}