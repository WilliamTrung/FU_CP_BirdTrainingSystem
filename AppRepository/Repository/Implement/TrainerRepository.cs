using AppCore.Context;
using AppCore.Models;
using AppRepository.Generic;
using AppRepository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRepository.Repository.Implement
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
