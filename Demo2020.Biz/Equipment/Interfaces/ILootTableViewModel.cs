using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ILootTableViewModel
    {
        ILootTableModel CurrentLootTable { get; set; }
        IList<ILootTableModel> LootTables { get; set; }
    }
}
