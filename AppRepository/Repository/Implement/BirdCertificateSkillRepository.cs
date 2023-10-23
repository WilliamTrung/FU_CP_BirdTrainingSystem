using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class BirdCertificateSkillRepository : GenericRepository<BirdCertificateSkill>, IBirdCertificateSkillRepository
    {
        public BirdCertificateSkillRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
