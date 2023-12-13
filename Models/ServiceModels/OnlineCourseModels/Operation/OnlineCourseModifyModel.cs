using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.OnlineCourseModels.Operation
{
    public class OnlineCourseModifyModel
    {
        public int Id { get; set; }
        public string? Title { get; set; } = null!;
        public string? ShortDescription { get; set; } = null!;
        public string? Picture { get; set; } = null!;
        public decimal? Price { get; set; }
    }
}
