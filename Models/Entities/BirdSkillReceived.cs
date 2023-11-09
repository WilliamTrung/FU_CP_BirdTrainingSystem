using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BirdSkillReceived
    {
        public int BirdSKillId { get; set; }
        public int BirdId { get; set; }
        public DateTime DateReceive { get; set; }

        public virtual Bird? Bird { get; set; }
        public virtual BirdSkill? BirdSkill { get; set; }
    }
}
