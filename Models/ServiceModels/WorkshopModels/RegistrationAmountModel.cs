using Models.ConfigModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.WorkshopModels
{
    public class RegistrationAmountModel
    {
        public int? ClassId { get; set; }   
        public int Registered { get; set; }
        public int Maximum { get; set; }
    }
}
