using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    class CustomerWorkshopPayment
    {
        enum Status
        {
            NotPayed = 0,
            Payed = 1,
            NotPayedEnough = 3
        }
    }
}
