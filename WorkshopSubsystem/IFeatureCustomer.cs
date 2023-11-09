﻿using Microsoft.Win32;
using Models.Entities;
using Models.ServiceModels.WorkshopModels;
using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkshopSubsystem
{
    public interface IFeatureCustomer : IFeatureAll
    {

        //Register workshop class
        //param: 
        //"customerId : int
        //WorkshopClassId : int
        Task Register(int customerId, int workshopClassId);
        Task<IEnumerable<WorkshopClassViewModel>> GetClassesByWorkshopId(int customerId, int workshopId);
        Task<IEnumerable<WorkshopClassViewModel>> GetRegisteredWorkshopClass(int customerId, int workshopId);

        Task<IEnumerable<WorkshopModel>> GetRegisteredWorkshops(int customerId);
        Task OnPurchaseClass(int customerId, int workshopClassId, BillingModel billingModel);
        Task<CustomerWorkshopClass?> GetCustomerRegistrationInfo(int customerId, int workshopClassId);
        Task<PreBillingInformation> GetPreBillingInformation(int customerId, int workshopClassId);
        Task Feedback(int customerId, int workshopId, string feedback);
        Task<string> GetFeedback(int customerId, int workshopId);
        Task Rate(int customerId, int workshopId, int rate);
        Task<int> GetRating(int customerId, int workshopId);
    }
}
