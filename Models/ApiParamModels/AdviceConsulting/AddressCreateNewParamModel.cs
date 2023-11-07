using Models.ServiceModels.AdviceConsultantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ApiParamModels.AdviceConsulting
{
    public class AddressCreateNewParamModel
    {
        public string? AddressDetail { get; set; }

        public CreateNewAddressServiceModel Convert_ParamModel_ServiceModel(int customerId) 
        {
            var model = new CreateNewAddressServiceModel()
            {
                CustomerId = customerId,
                AddressDetail = AddressDetail
            };

            return model;
        }
    }
}
