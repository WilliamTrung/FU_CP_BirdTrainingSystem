using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class ConsultingPricePolicy
    {
        public ConsultingPricePolicy()
        {
            DistancePrices = new HashSet<DistancePrice>();
        }

        public int Id { get; set; }
        public int ConsultingTypeId { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? ExtendPrice { get; set; }

        public virtual ConsultingType ConsultingType { get; set; } = null!;
        public virtual ICollection<DistancePrice> DistancePrices { get; set; }
    }
}
