﻿using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class AdditionalConsultingBillRepository : GenericRepository<AdditionalConsultingBill>, IAdditionalConsultingBillRepository
    {
        public AdditionalConsultingBillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}