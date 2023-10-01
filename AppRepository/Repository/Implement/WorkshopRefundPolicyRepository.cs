﻿using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class WorkshopRefundPolicyRepository : GenericRepository<WorkshopRefundPolicy>, IWorkshopRefundPolicyRepository
    {
        public WorkshopRefundPolicyRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
