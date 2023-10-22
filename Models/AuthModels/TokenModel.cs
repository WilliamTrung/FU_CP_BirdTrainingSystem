using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.AuthModels
{
    public interface ITokenModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Avatar { get; set; }
        Models.Enum.Role Role { get; set; }
    }
    public class TokenModel : ITokenModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Avatar { get; set; } = null!;        
        public Models.Enum.Role Role { get; set; }
    }
}
