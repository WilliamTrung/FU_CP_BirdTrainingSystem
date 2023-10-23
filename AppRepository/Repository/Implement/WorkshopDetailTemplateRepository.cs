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
    public class WorkshopDetailTemplateRepository : GenericRepository<WorkshopDetailTemplate>, IWorkshopDetailTemplateRepository
    {
        public WorkshopDetailTemplateRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
