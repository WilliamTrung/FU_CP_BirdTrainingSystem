using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.UserModels.Profile
{
    public class ProfileViewModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Avatar { get; set; } = string.Empty;
        public Models.Enum.Role Role { get; set; }
        public DateTime? BirthDay { get; set; }
        public bool? Gender { get; set; }
        public decimal? TotalPayment { get; set; }
        public string? Membership { get; set; }
        public string? GgMeetLink {  get; set; }
        public bool? IsFulltime { get; set; }
        public string? Status { get; set; }
    }
}
