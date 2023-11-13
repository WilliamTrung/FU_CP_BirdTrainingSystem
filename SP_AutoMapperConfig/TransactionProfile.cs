using AppCore.Models;
using AutoMapper;
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
        }

        private void Map_TransactionAddModel_Transaction()
        {
            CreateMap<TransactionAddModel, Transaction>();
        }
    }
}
