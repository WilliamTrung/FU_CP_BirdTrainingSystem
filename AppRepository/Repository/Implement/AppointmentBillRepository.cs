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
    public class AppointmentBillRepository : GenericRepository<AppointmentBill>, IAppointmentBillRepository
    {
        public AppointmentBillRepository(BirdTrainingCenterSystemContext context, IUnitOfWork unitOfWork) : base(context, unitOfWork)
        {
        }
    }
}
