using AppRepository.Generic;
using AppRepository.UnitOfWork;
using Models.Entities;

namespace AppRepository.Repository.Implement
{
    public class WorkshopAttendanceRepository : GenericRepository<WorkshopAttendance>, IWorkshopAttendanceRepository
    {
        public WorkshopAttendanceRepository(AppCore.Context.BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
