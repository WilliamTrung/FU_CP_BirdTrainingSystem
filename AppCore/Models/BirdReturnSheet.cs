using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class BirdReturnSheet
    {
        public int Id { get; set; }
        public int StaffBirdReceivedId { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string? Note { get; set; }
        public string? Picture { get; set; }
        public decimal? AdditionalPrice { get; set; }

        public virtual StaffBirdReceived StaffBirdReceived { get; set; } = null!;
    }
}
