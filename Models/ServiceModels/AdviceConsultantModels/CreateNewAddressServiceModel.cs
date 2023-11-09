using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class CreateNewAddressServiceModel
    {
        public int CustomerId { get; set; }
        public string? AddressDetail { get; set; }
    }
}
