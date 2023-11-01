using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserStatusUpdateModel
    {
        public int Id { get; set; }
        public string Status { get; set; } = null!;
    }
}
