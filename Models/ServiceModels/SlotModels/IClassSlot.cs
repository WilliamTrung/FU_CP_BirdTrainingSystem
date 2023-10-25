using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.SlotModels
{
    public interface IClassSlot : ISlotModel
    {
        DateTime? Date { get; set; }
    }
}
