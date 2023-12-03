using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class DistancePricePolicyUpdateServiceModel
    {
        public int Id { get; set; }
        public decimal PricePerKm { get; set; }
    }
}
