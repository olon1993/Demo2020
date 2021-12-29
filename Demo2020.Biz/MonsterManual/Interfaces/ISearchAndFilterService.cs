﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface ISearchAndFilterService
    {
        IList<IMonster> Filter(IList<IMonster> list, string filter);
    }
}