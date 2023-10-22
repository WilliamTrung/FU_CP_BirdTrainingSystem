using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthModels
{
    public class CustomerAddModel
    {
        public int UserId { get; set; }
        public int MembershipRankId { get; } = 1;
        public int Status { get; } = (int)Models.Enum.Customer.Status.Active;
    }
}
