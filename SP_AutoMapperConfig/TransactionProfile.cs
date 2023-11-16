using AutoMapper;
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
        }

        private void Map_TransactionAddModel_Transaction()
        {
            CreateMap<TransactionAddModel, Transaction>();
        }
    }
}
