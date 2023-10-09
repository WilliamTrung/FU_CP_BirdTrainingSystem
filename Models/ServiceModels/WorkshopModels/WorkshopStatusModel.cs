using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class WorkshopStatusModel
    {
        public int Value { get; set; }
        public string Name { get; set; } = null!;
        public static IEnumerable<WorkshopStatusModel> All()
        {
            List<WorkshopStatusModel> statuses = new List<WorkshopStatusModel>();
            statuses.Add(new WorkshopStatusModel
            {
                Value = (int)Models.Enum.Workshop.Status.Inactive,
                Name = "Inactive"
            });
            statuses.Add(new WorkshopStatusModel
            {
                Value = (int)Models.Enum.Workshop.Status.Active,
                Name = "Active"
            });
            return statuses;
        }
    }
}
