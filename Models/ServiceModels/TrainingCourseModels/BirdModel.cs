using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class BirdModel
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int BirdSpeciesId { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public bool? IsDefault { get; set; }
        public int Status { get; set; }

        public virtual BirdSpeciesModel BirdSpecies { get; set; } = null!;
        //public virtual Customer Customer { get; set; } = null!;
        //public virtual ICollection<BirdCertificateDetail> BirdCertificateDetails { get; set; }
        public virtual ICollection<BirdTrainingCourseModel> BirdTrainingCourses { get; set; }
    }
}