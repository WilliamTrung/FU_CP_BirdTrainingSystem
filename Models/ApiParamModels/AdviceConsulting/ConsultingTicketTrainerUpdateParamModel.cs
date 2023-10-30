using Microsoft.AspNetCore.Http;
using Models.ServiceModels.AdviceConsultantModels.ConsultingTicket;
using SP_Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.AdviceConsulting
{
    public class ConsultingTicketTrainerUpdateParamModel
    {
        public int Id { get; set; }
        public int? ActualEndSlot { get; set; }
        [FileImageValidator]
        public List<IFormFile> Evidence { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountedPrice { get; set; }
        public int Status { get; set; }
        
        public ConsultingTicketTrainerFinishModel ToConsultingTicketUpdateModel(string evidence)
        {
            return new ConsultingTicketTrainerFinishModel
            {
                Id = this.Id,
                ActualEndSlot = (int)this.ActualEndSlot,
                Price = this.Price,
                DiscountedPrice = this.DiscountedPrice,
                Status = this.Status
            };
        }
    }
}
