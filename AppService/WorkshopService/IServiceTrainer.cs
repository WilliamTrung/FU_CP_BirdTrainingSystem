﻿using Models.ServiceModels.WorkshopModels.WorkshopClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService.WorkshopService
{
    public interface IServiceTrainer : IServiceAll
    {
        Task ModifyWorkshopClassDetail(WorkshopClassDetailModifyModel model);
    }
}