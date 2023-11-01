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
    }
    public class TrainingCourse : ITrainingCourseService
    {
        private readonly IServiceCustomer _customer;
        private readonly IServiceStaff _staff;
        private readonly IServiceManager _manager;
        private readonly IServiceTrainer _trainer;
        public TrainingCourse(IServiceCustomer customer, IServiceStaff staff, IServiceManager manager, IServiceTrainer trainer)
        {
            _customer = customer;
            _staff = staff;
            _manager = manager;
            _trainer = trainer;
        }

        public IServiceCustomer Customer => _customer;

        public IServiceStaff Staff => _staff;

        public IServiceManager Manager => _manager;

        public IServiceTrainer Trainer => _trainer;
    }
}
