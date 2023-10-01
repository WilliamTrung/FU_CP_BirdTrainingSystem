﻿using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class CustomerWorkshopClassRepository : GenericRepository<CustomerWorkshopClass>, ICustomerWorkshopClassRepository
    {
        public CustomerWorkshopClassRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
