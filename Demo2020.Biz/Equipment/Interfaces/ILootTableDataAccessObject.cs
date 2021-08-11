using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ILootTableDataAccessObject
    {
        Task<ILootTable> GetLootTable(int id);
        Task<ILootTable> GetLootTable(string name);
        Task<IList<ILootTable>> GetLootTables();
        Task<bool> UpdateLootTable(ILootTable lootTable);
        Task<bool> SaveLootTable(ILootTable lootTable);
        Task<bool> DeleteLootTable(ILootTable lootTable);
    }
}
