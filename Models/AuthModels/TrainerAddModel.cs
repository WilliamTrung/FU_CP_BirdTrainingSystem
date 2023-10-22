using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthModels
{
    public class TrainerAddModel
    {
        public int UserId { get; set; }
        public int Status { get; } = (int)Models.Enum.Trainer.Status.Working;
        public bool IsFullTime { get; } = true;
    }
}
