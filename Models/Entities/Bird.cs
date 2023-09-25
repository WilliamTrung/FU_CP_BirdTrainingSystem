using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Bird
    {
        public Bird()
        {
            BirdTrainingCourses = new HashSet<BirdTrainingCourse>();
            StaffBirdReceiveds = new HashSet<StaffBirdReceived>();
            UserBirdBirdCertificates = new HashSet<BirdCertificateDetail>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SystemBirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? OrtherDescription { get; set; }

        public virtual Customer Customer { get; set; } = null!;
        public virtual BirdSpecies SystemBirdSpecies { get; set; } = null!;
        public virtual ICollection<BirdTrainingCourse> BirdTrainingCourses { get; set; }
        public virtual ICollection<StaffBirdReceived> StaffBirdReceiveds { get; set; }
        public virtual ICollection<BirdCertificateDetail> UserBirdBirdCertificates { get; set; }
    }
}
