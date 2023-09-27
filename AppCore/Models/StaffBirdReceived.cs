using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class StaffBirdReceived
    {
        public StaffBirdReceived()
        {
            BirdCaringPricePolicies = new HashSet<BirdCaringPricePolicy>();
            BirdReceiveSheets = new HashSet<BirdReceiveSheet>();
            BirdReturnSheets = new HashSet<BirdReturnSheet>();
        }

        public int Id { get; set; }
        public int StaffId { get; set; }
        public int BirdId { get; set; }
        public DateTime? TrainingDoneDate { get; set; }
        public DateTime? ExpectedDateReturn { get; set; }
        public int? Status { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual User Staff { get; set; } = null!;
        public virtual ICollection<BirdCaringPricePolicy> BirdCaringPricePolicies { get; set; }
        public virtual ICollection<BirdReceiveSheet> BirdReceiveSheets { get; set; }
        public virtual ICollection<BirdReturnSheet> BirdReturnSheets { get; set; }
    }
}
