using System;
using System.Collections.Generic;

namespace Models.Entities
{
    public partial class Workshop
    {
        public Workshop()
        {
            CustomerWorkshopPayments = new HashSet<CustomerWorkshopPayment>();
            TrainerWorkshops = new HashSet<TrainerWorkshop>();
        }

        public int Id { get; set; }
        public int WorkShopCategoryId { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? RegisterEndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public decimal? Price { get; set; }
        public bool? WorkshopStatus { get; set; }
        public int TrainerId { get; set; }

        public virtual WorkShopCategory WorkShopCategory { get; set; } = null!;
        public virtual ICollection<CustomerWorkshopPayment> CustomerWorkshopPayments { get; set; }
        public virtual ICollection<TrainerWorkshop> TrainerWorkshops { get; set; }
    }
}
