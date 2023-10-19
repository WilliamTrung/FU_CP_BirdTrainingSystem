using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class WorkshopDetailTemplate
    {
        public int Id { get; set; } 
        public int WorkshopId { get; set; }
        public string Detail { get; set; } = null!;
        public virtual Workshop Workshop { get; set; } = null!;
        public virtual ICollection<WorkshopClassDetail> WorkshopClassDetails { get; set; } = null!;
    }
}
