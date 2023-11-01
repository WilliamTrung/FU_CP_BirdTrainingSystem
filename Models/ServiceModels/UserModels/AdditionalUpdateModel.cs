using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class AdditionalUpdateModel : UserUpdateModel
    {
        public bool? Gender { get; set; }
        public DateTime? BirthDay { get; set; }         
    }
}
