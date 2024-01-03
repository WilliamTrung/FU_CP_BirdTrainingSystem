using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class User
    {
        public User()
        {
            BirdTrainingCourses = new HashSet<BirdTrainingCourse>();
            Customers = new HashSet<Customer>();
            Trainers = new HashSet<Trainer>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal PhoneNumber { get; set; }
        public string? Avatar { get; set; }
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }

        public virtual ICollection<BirdTrainingCourse> BirdTrainingCourses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
