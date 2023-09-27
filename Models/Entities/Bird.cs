using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Bird
    {
        public Bird()
        {
            BirdBirdCertificateDetails = new HashSet<BirdCertificateDetail>();
            BirdTrainingCourses = new HashSet<BirdTrainingCourse>();
            StaffBirdReceiveds = new HashSet<StaffBirdReceived>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SystemBirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? OrtherDescription { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual BirdSpecies SystemBirdSpecies { get; set; } = null!;
        public virtual ICollection<BirdCertificateDetail> BirdBirdCertificateDetails { get; set; }
        public virtual ICollection<BirdTrainingCourse> BirdTrainingCourses { get; set; }
        public virtual ICollection<StaffBirdReceived> StaffBirdReceiveds { get; set; }
    }
}
