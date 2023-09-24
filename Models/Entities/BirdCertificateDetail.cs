using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class BirdCertificateDetail
    {
        public int BirdId { get; set; }
        public int BirdCertificateId { get; set; }
        public DateTime? ReceiveDate { get; set; }

        public virtual Bird Bird { get; set; } = null!;
        public virtual BirdCertificate BirdCertificate { get; set; } = null!;
    }
}
