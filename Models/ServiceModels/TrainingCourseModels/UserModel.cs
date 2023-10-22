using Models.ServiceModels.TrainingCourseModels.BirdTrainingCourse;
using System;
using System.Collections.Generic;

namespace Models.ServiceModels.TrainingCourseModels
{
    public partial class UserModel
    {
        public UserModel()
        {
            BirdTrainingCourses = new HashSet<BirdTrainingCourseModel>();
            Customers = new HashSet<CustomerModel>();
            Trainers = new HashSet<TrainerModel>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public decimal? PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual ICollection<BirdTrainingCourseModel> BirdTrainingCourses { get; set; }
        public virtual ICollection<CustomerModel> Customers { get; set; }
        public virtual ICollection<TrainerModel> Trainers { get; set; }
    }
}