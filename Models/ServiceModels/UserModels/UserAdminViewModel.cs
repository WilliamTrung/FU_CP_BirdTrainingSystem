﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels
{
    public class UserAdminViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!; 
        public string Avatar { get; set; } = string.Empty;
        public string Password { get; set; } = null!;
        public Models.Enum.Role Role { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Gender { get; set; }
        public bool? Consultantable { get; set; }
        public decimal? TotalPayment { get; set; }
        public string? Membership { get; set; } 
        public bool? IsFulltime { get; set; }
        public string? Status { get; set; }

    }
}
