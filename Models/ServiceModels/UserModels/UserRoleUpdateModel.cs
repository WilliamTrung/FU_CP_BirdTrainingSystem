using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserRoleUpdateModel
    {
        public int Id { get; set; }
        public Models.Enum.Role Role { get; set; }
    }
}
