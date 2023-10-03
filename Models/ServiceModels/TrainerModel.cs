using Models.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels
{
    public class TrainerModel
    {
        public int Id { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool Gender { get; set; }
        public bool IsFullTime { get; set; }
        public Models.Enum.Trainer.Status Status { get; set; }
        public List<TrainerSkillModel> Skills { get; set; } = null!;
    }
}
