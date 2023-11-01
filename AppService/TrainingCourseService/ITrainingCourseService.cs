using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.TrainingCourseService
{
    public interface ITrainingCourseService
    {
        IServiceCustomer Customer { get; }
        IServiceStaff Staff { get; }
        IServiceManager Manager { get; }
        IServiceTrainer Trainer { get; }
        IServiceAll All { get; }
    }
    public class TrainingCourse : ITrainingCourseService
    {
        private readonly IServiceCustomer _customer;
        private readonly IServiceStaff _staff;
        private readonly IServiceManager _manager;
        private readonly IServiceTrainer _trainer;
        private readonly IServiceAll _all;
        public TrainingCourse(IServiceCustomer customer, IServiceStaff staff, IServiceManager manager, IServiceTrainer trainer, IServiceAll all)
        {
            _customer = customer;
            _staff = staff;
            _manager = manager;
            _trainer = trainer;
            _all = all;
        }

        public IServiceCustomer Customer => _customer;

        public IServiceStaff Staff => _staff;

        public IServiceManager Manager => _manager;

        public IServiceTrainer Trainer => _trainer;

        public IServiceAll All => _all;
    }
}
