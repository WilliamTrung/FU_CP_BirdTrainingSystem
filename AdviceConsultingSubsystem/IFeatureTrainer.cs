using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IFeatureTrainer
    {
        //FE16[Trainer] view assigned[Appointment] by[Staff]
        //FE17[Trainer] decide on planning a[Training Plan] for [Appointment] - optional
        //FE18[Trainer] fill out [Billing Form] from the advice appointment - after completing the appointment
        //FE19[Trainer] confirm getting paid from[Customer] by given information from[Billing Form]
    }
}
