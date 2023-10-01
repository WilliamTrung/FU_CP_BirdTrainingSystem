﻿using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class CertificateRepository : GenericRepository<Certificate>, ICertificateRepository
    {
        public CertificateRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
