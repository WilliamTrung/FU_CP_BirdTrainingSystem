using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserRoleUpdateModel
    {
        public int? TrainerId { get; set; }
        public int? UserId { get; set; }
        public Models.Enum.Role Role { get; set; }
    }
}
