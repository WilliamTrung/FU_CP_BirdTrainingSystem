using AppCore.Context;
using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository.Repository.Implement
{
    public class BirdSkillReceivedRepository : GenericRepository<BirdSkillReceived>, IBirdSkillReceivedRepository
    {
        public BirdSkillReceivedRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
        public override Task Add(BirdSkillReceived entity)
        {
            entity.ReceivedDate = DateTime.Now;
            return base.Add(entity);
        }
    }
}
