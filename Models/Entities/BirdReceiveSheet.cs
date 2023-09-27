using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdReceiveSheet
    {
        public int Id { get; set; }
        public int StaffBirdReceivedId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? Note { get; set; }
        public string? Picture { get; set; }

        public virtual StaffBirdReceived StaffBirdReceived { get; set; } = null!;
    }
}
