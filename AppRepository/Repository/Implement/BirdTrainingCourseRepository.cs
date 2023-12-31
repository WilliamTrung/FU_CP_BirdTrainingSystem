﻿using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;
using System.Linq.Expressions;

namespace AppRepository.Repository.Implement
{
    public class BirdTrainingCourseRepository : GenericRepository<BirdTrainingCourse>, IBirdTrainingCourseRepository
    {
        public BirdTrainingCourseRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        //public override async Task<IEnumerable<BirdTrainingCourse>> Get(Expression<Func<BirdTrainingCourse, bool>>? expression = null, params string[] includeProperties)
        //{
        //    var entities = await base.Get(expression, includeProperties);
        //    foreach (var entity in entities)
        //    {
        //        if (entity != null)
        //        {
        //            if (entity.StartTrainingDate != null)
        //            {
        //                int compareDate = DateTime.Compare(DateTime.Now, (DateTime)entity.StartTrainingDate);
        //                if (entity.Status == (int)Models.Enum.BirdTrainingCourse.Status.CheckIn && compareDate >= 0)
        //                {
        //                    entity.Status = (int)Models.Enum.BirdTrainingCourse.Status.Training;
        //                    await Update(entity);
        //                }
        //            }
        //        }
        //    }
        //    return entities;
        //}
    }
}
