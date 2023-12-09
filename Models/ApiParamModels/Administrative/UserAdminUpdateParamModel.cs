using Microsoft.AspNetCore.Http;
using Models.Enum;
using Models.ServiceModels.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.Administrative
{
    public class UserAdminUpdateParamModel
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string? Name { get; set; }
        //public string? Email { get; set; }
        public IFormFile? Avatar { get; set; }
        [SP_Validator.PhoneValidator]
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public bool? Gender { get; set; }
        public DateTime? BirthDay { get; set; }
        public string? GgMeetLink { get; set; }
        public bool? Consultantable { get; set; }
        public bool? IsFullTime { get; set; }
        public UserAdminUpdateModel ToModel() {
            return new UserAdminUpdateModel { 
                Id = this.Id,
                Role = this.Role,
                Name = this.Name,
                //Email = this.Email,
                BirthDay = this.BirthDay,
                Gender = this.Gender,
                GgMeetLink = this.GgMeetLink,
                PhoneNumber = this.PhoneNumber,
                Password = this.Password,
                Consultantable = this.Consultantable,
                IsFullTime = this.IsFullTime,
            };
        }

    }
}
