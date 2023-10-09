using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Bird
    {
        public Bird()
        {
            BirdCertificateDetails = new HashSet<BirdCertificateDetail>();
            BirdTrainingCourses = new HashSet<BirdTrainingCourse>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }

        public virtual BirdSpecies BirdSpecies { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual ICollection<BirdCertificateDetail> BirdCertificateDetails { get; set; }
        public virtual ICollection<BirdTrainingCourse> BirdTrainingCourses { get; set; }
    }
}
