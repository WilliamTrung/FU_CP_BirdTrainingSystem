﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppService
{
    public interface IGoogleMapService
    {
        Task<float> CalculateDistance(string destination);
    }
}
