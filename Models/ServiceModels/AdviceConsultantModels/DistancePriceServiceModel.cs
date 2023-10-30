using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class DistancePriceServiceModel
    {
        public int Id { get; set; }
        public int? From { get; set; }
        public int? To { get; set; }
        public decimal? PricePerKm { get; set; }
    }
}
