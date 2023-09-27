using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class DistancePrice
    {
        public int Id { get; set; }
        public int ConsultingPricePolicyId { get; set; }
        public int? Distance { get; set; }
        public int? FreeDistance { get; set; }
        public decimal? BasePrice { get; set; }
        public decimal? PricePerKm { get; set; }

        public virtual ConsultingPricePolicy ConsultingPricePolicy { get; set; } = null!;
    }
}
