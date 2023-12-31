﻿using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class CustomerOnlineCourseDetailRepository : GenericRepository<CustomerOnlineCourseDetail>, ICustomerOnlineCourseDetailRepository
    {
        public CustomerOnlineCourseDetailRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
