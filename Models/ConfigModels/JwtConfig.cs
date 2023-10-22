using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ConfigModels
{
    public class JwtConfig
    {
        public string Key { get; set; } = null!;
        public string Audience { get; set; } = null!; 
        public string Issuer { get; set; } = null!; 
    }
}
