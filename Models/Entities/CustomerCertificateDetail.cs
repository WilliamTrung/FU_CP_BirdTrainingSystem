using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class CustomerCertificateDetail
    {
        public int CustomerId { get; set; }
        public int CertificateId { get; set; }
        public DateTime? ReceiveDate { get; set; }

        public virtual Certificate Certificate { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
    }
}
