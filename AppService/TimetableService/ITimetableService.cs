using AppService.TimetableService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TimetableService
{
    public interface ITimetableService
    {
        IServiceAll All { get; }
        //IServiceCustomer Customer { get; }
        IServiceStaff Staff { get; }
        IServiceManager Manager { get; }
        IServiceTrainer Trainer { get; }
    }
    public class TimetableService : ITimetableService
    {
        private readonly IServiceAll _all;
        //private readonly IServiceCustomer _customer;
        private readonly IServiceStaff _staff;
        private readonly IServiceManager _manager;
        private readonly IServiceTrainer _trainer;
        public TimetableService(IServiceAll all, IServiceStaff staff, IServiceManager manager, IServiceTrainer trainer)
        {
            _all = all;
            //_customer = customer;
            _staff = staff;
            _manager = manager;
            _trainer = trainer;
        }

        public IServiceAll All => _all;

        //public IServiceCustomer Customer => _customer;

        public IServiceStaff Staff => _staff;

        public IServiceManager Manager => _manager;

        public IServiceTrainer Trainer => _trainer;
    }
}
