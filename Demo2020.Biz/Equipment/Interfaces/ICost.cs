﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ICost
    {
        long Quantity { get; set; }

        string Unit { get; set; }
    }
}
