using AutoMapper;
using Models.DashboardModels;
using Models.Entities;
using Models.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_AutoMapperConfig
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile() 
        {
            Map_TransactionAddModel_Transaction();
            Map_Transaction_TransactionModel();
        }

        private void Map_TransactionAddModel_Transaction()
        {
            CreateMap<TransactionAddModel, Transaction>();
        }
        private void Map_Transaction_TransactionModel()
        {
#pragma warning disable CS8629 // Nullable value type may be null.
            CreateMap<Transaction, TransactionModel>()
                .ForMember(m => m.PaymentCode, opt => opt.MapFrom(e => e.PaymentCode))
                .ForMember(m => m.DateTime, opt => opt.MapFrom(e => e.PaymentDate))
                .ForMember(m => m.Cost, opt => opt.MapFrom(e => e.TotalPayment))
                .ForMember(m => m.Email, opt => opt.MapFrom(e => e.Customer.User.Email))
                .ForMember(m => m.Type, opt => opt.MapFrom(e => (Models.Enum.EntityType)e.EntityTypeId.Value));
#pragma warning restore CS8629 // Nullable value type may be null.
        }
    }
}
