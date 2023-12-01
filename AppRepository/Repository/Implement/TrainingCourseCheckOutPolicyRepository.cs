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
    public class TrainingCourseCheckOutPolicyRepository : GenericRepository<TrainingCourseCheckOutPolicy>, ITrainingCourseCheckOutPolicyRepository
    {
        public TrainingCourseCheckOutPolicyRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
