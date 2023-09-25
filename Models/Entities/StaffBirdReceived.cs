using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class StaffBirdReceived
    {
        public int Id { get; set; }
        public int BirdId { get; set; }
        public int StaffId { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public DateTime? ExpectedDateReturn { get; set; }
        public DateTime? ReturnDate { get; set; }
        public decimal? FinalPrice { get; set; }
        public string? Status { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual User Staff { get; set; } = null!;
    }
}
