using AppRepository.UnitOfWork;
using AutoMapper;
using Models.Entities;
using Models.ServiceModels.TrainingCourseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrainingCourseSubsystem.Implementation
{
    public class FeatureManager : FeatureAll, IFeatureManager
    {
        public FeatureManager(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        public async Task CreateCourse(TrainingCourseModel trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<TrainingCourse>(trainingCourse);
            entity.TotalSlot = 0;
            entity.Status = (int) Models.Enum.TrainingCourse.Status.Modifying;
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.TrainingCourseRepository.Add(entity);
        }
        public async Task EditCourse(TrainingCourseModel trainingCourse)
        {
            if (trainingCourse == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourse.Id).Result;
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            else
            {
                entity.BirdSpeciesId = trainingCourse.BirdSpeciesId;
                entity.Title = trainingCourse.Title;
                entity.Description = trainingCourse.Description;
                entity.Picture = trainingCourse.Picture;
                entity.TotalPrice = trainingCourse.TotalPrice;
                entity.Status = (int)Models.Enum.TrainingCourse.Status.Modifying;
                await _unitOfWork.TrainingCourseRepository.Update(entity);
            }
        }

        public async Task DisableTrainingCourse(int trainingCourseId)
        {
            var entity = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId).Result;
            if (entity == null)
            {
                throw new Exception("Entity is not found.");
            }
            else
            {
                entity.Status = (int) Models.Enum.TrainingCourse.Status.Disable;
                await _unitOfWork.TrainingCourseRepository.Update(entity);
            }
        }

        public async Task ActiveTrainingCourse(int trainingCourseId)
        {
            var entity = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseId).Result;
            if (entity == null)
            {
                throw new Exception("Entity is not found.");
            }
            else
            {
                entity.Status = (int)Models.Enum.TrainingCourse.Status.Active;
                await _unitOfWork.TrainingCourseRepository.Update(entity);
            }
        }

        public async Task AddSkill(TrainingCourseSkillModel trainingCourseSkill)
        {
            if (trainingCourseSkill == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<TrainingCourseSkill>(trainingCourseSkill);
            var trainingCourse = _unitOfWork.TrainingCourseRepository.GetFirst(e => e.Id == trainingCourseSkill.TrainingCourseId).Result;
            if(trainingCourse == null)
            {
                throw new Exception("Training Course not found");
            }
            else
            {
                trainingCourse.TotalSlot += entity.TotalSlot;
            }
            if (entity == null)
            {
                throw new Exception("Mapping is failed.");
            }
            await _unitOfWork.TrainingCourseSkillRepository.Add(entity);
            await _unitOfWork.TrainingCourseRepository.Update(trainingCourse);
        }

        public async Task CreateBirdSpecies(BirdSpeciesModel birdSpecies)
        {
            if (birdSpecies == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = _mapper.Map<BirdSpecies>(birdSpecies);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            await _unitOfWork.BirdSpeciesRepository.Add(entity);
        }

        public async Task EditBirdSpecies(BirdSpeciesModel birdSpecies)
        {
            if (birdSpecies == null)
            {
                throw new Exception("Client send null model.");
            }
            var entity = await _unitOfWork.BirdSpeciesRepository.GetFirst(e => e.Id == birdSpecies.Id);
            if (entity == null)
            {
                throw new Exception("Entity is null.");
            }
            entity.Name = birdSpecies.Name;
            entity.ShortDetail = birdSpecies.ShortDetail;
            await _unitOfWork.BirdSpeciesRepository.Update(entity);
        }
    }
}
