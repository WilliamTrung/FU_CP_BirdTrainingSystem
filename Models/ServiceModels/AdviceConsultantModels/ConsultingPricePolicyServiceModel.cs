using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ServiceModels.AdviceConsultantModels
{
    public class ConsultingPricePolicyServiceModel
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public bool OnlineOrOffline { get; set; }
    }
}
