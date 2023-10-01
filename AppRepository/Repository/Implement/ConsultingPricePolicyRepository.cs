﻿using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class ConsultingPricePolicyRepository : GenericRepository<ConsultingPricePolicy>, IConsultingPricePolicyRepository
    {
        public ConsultingPricePolicyRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
