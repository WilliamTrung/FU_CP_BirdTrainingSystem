using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class User
    {
        public User()
        {
            Customers = new HashSet<Customer>();
            StaffBirdReceiveds = new HashSet<StaffBirdReceived>();
            Trainers = new HashSet<Trainer>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string Email { get; set; } = null!;
        public decimal? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<StaffBirdReceived> StaffBirdReceiveds { get; set; }
        public virtual ICollection<Trainer> Trainers { get; set; }
    }
}
