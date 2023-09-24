using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdviceConsultingSubsystem
{
    public interface IFeatureStaff
    {
        //FE10[Staff] view[Help ticket] from[Customer]
        //FE11[Staff] reply[Help ticket] to[Customer]
        //FE13	[Staff] view [Advice ticket] from [Customer]
        //FE14[Staff] create[Appointment] from[Advice ticket]
        //FE15[Staff] choose free[Trainer] to assign to[Appointment]
        //FE20[Staff] set the[Advice ticket] status to "Completed" - by confirming the[Trainer] has completed the[Advice ticket]
    }
}
