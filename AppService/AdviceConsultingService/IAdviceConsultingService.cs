using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.AdviceConsultingService
{
    public interface IAdviceConsultingService
    {
        IOtherService Other { get; }
        IServiceCustomer Customer { get; }
        IServiceStaff Staff {  get; }
        IServiceTrainer Trainer { get; }
    }

    public class AdviceConsultingSerivce : IAdviceConsultingService
    {
        private readonly IOtherService _other;
        private readonly IServiceCustomer _customer;
        private readonly IServiceStaff _staff;
        private readonly IServiceTrainer _trainer;
        public AdviceConsultingSerivce (IOtherService other, IServiceCustomer customer, IServiceStaff staff, IServiceTrainer trainer)
        {
            _other = other;
            _customer = customer;
            _staff = staff;
            _trainer = trainer;
        }

        public IOtherService Other => _other;
        public IServiceCustomer Customer => _customer;
        public IServiceStaff Staff => _staff;
        public IServiceTrainer Trainer => _trainer;
    }
}
