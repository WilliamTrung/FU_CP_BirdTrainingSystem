using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class TrainerWorkshopModel
    {
        /*
         * [Trainer]:
            + id : int
            + name : string
            + email : string
            + avatar : string
         */
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Avatar { get; set; } = null!;
    }
}
