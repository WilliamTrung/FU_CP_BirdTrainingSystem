﻿namespace AppCore.Models
{
    public partial class ConsultingTicket
    {
        public ConsultingTicket()
        {
            AdditionalConsultingBills = new HashSet<AdditionalConsultingBill>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public int ConsultingTypeId { get; set; }
        public int TrainerId { get; set; }
        public DateTime? ExpectedDate { get; set; }
        public int? ExpectedSlotStart { get; set; }
        public int? ExpectedSlotEnd { get; set; }
        public string? ConsultingDetail { get; set; }
        public int? Distance { get; set; }
        public bool? OnlineOrOffline { get; set; }
        public string? GgMeetLink { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public int? ActualSlotStart { get; set; }
        public int? ActualEndSlot { get; set; }
        public decimal? Price { get; set; }
        public int? Status { get; set; }
        public int ConsultingPricePolicyId { get; set; }
        public int DistancePriceId { get; set; }

        public virtual Address Address { get; set; } = null!;
        public virtual ConsultingPricePolicy ConsultingPricePolicy { get; set; } = null!;
        public virtual ConsultingType ConsultingType { get; set; } = null!;
        public virtual Customer Customer { get; set; } = null!;
        public virtual DistancePrice DistancePrice { get; set; } = null!;
        public virtual Trainer Trainer { get; set; } = null!;
        public virtual ICollection<AdditionalConsultingBill> AdditionalConsultingBills { get; set; }
    }
}
