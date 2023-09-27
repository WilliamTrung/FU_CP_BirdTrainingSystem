using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdCaringPricePolicy
    {
        public int Id { get; set; }
        public int StaffBirdReceivedId { get; set; }
        public int? FreeDate { get; set; }
        public decimal? PricePerDate { get; set; }

        public virtual StaffBirdReceived StaffBirdReceived { get; set; } = null!;
    }
}
