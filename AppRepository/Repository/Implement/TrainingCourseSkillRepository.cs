﻿using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class TrainingCourseSkillRepository : GenericRepository<TrainingCourseSkill>, ITrainingCourseSkillRepository
    {
        public TrainingCourseSkillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}