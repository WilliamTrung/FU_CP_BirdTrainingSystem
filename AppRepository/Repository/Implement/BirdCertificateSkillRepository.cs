using Models.Entities;
using AppRepository.Generic;
using AppRepository.UnitOfWork;

namespace AppRepository.Repository.Implement
{
    public class BirdCertificateSkillRepository : GenericRepository<BirdCertificateSkill>, IBirdCertificateSkillRepository
    {
        public BirdCertificateSkillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
