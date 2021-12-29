﻿using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class LootTableSearchAndFilterService : ILootTableSearchAndFilter
    {
        public IList<ILootTable> Filter(IList<ILootTable> list, string filter)
        {
            IList<ILootTable> results = new List<ILootTable>();
            foreach (ILootTable lootTable in list)
            {
                string buffer = lootTable.Name.ToLower();
                if (buffer.Contains(filter.ToLower()))
                {
                    results.Add(lootTable);
                }
            }

            return results;
        }
    }
}