using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.OnlineCourseService
{
    public interface IOnlineCourseService
    {
        IServiceAll All { get;}
        IServiceCustomer Customer { get;}
        IServiceStaff Staff { get;}
        IServiceManager Manager { get;}
    }

    public class OnlineCourseService : IOnlineCourseService
    {
        private readonly IServiceAll _all;
        private readonly IServiceCustomer _customer;
        private readonly IServiceStaff _staff;
        private readonly IServiceManager _manager;

        public OnlineCourseService(IServiceAll all, IServiceCustomer customer, IServiceStaff staff, IServiceManager manager)
        {
            _all = all;
            _customer = customer;
            _staff = staff;
            _manager = manager;
        }

        public IServiceAll All => _all;
        public IServiceCustomer Customer => _customer;
        public IServiceStaff Staff => _staff;
        public IServiceManager Manager => _manager;
    }
}
