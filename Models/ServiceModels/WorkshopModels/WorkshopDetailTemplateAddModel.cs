using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class WorkshopDetailTemplateAddModel
    {
        public WorkshopDetailTemplateAddModel(int workshopId)
        {
            WorkshopId = workshopId;
        }
        public int WorkshopId { get; private set; }
        public string Detail = String.Empty;
    }
}
