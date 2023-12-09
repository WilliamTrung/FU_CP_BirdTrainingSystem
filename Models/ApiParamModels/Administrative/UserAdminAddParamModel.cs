using Microsoft.AspNetCore.Http;
using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Administrative
{
    public class UserAdminAddParamModel
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        [SP_Validator.PhoneValidator]
        public string PhoneNumber { get; set; } = null!;
        public IFormFile? Avatar { get; set; }
        public string Password { get; set; } = null!;
        public Models.Enum.AdministrativeRole Role { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? GgMeetLink { get; set; }
        public bool? Gender { get; set; }
        public bool? Consultantable { get; set; }
        public bool? IsFulltime { get; set; }
        public UserAdminAddModel ToModel(string? picture)
        {
            return new UserAdminAddModel
            {
                Avatar = picture,
                BirthDay = BirthDay,
                Consultantable = Consultantable,
                Email = Email,
                Gender = Gender,
                GgMeetLink = GgMeetLink,
                IsFulltime = IsFulltime,
                Name = Name,
                Password = Password,
                PhoneNumber = PhoneNumber,
                Role = Role,                
            };
        }
    }
}
