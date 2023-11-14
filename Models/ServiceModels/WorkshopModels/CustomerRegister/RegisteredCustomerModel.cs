using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels.CustomerRegister
{
    public class RegisteredCustomerModel
    {
        public string Avatar { get; set; } = null!;
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;

    }
}
