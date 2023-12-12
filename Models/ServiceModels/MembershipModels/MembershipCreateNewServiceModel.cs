using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.MembershipModels
{
    public class MembershipCreateNewServiceModel
    {
        public string? Name { get; set; }
        public float? Discount { get; set; }
        public decimal? Requirement { get; set; }
    }
}
