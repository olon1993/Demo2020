﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz
{
    public class ProgramConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            


            return builder.Build();
        }
    }
}
