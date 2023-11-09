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
    }

    public class OnlineCourseService : IOnlineCourseService
    {
        private readonly IServiceAll _all;
        private readonly IServiceCustomer _customer;
        private readonly IServiceStaff _staff;

        public OnlineCourseService(IServiceAll all, IServiceCustomer customer, IServiceStaff staff)
        {
            _all = all;
            _customer = customer;
            _staff = staff;
        }

        public IServiceAll All => _all;
        public IServiceCustomer Customer => _customer;
        public IServiceStaff Staff => _staff;
    }
}
