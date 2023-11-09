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
        public int BirdSkillId { get; set; }
        public int BirdId { get; set; }
        public DateTime ReceivedDate { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual BirdSkill BirdSkill { get; set; } = null!;
    }
}
