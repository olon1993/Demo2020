using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ILootTableDataAccessService
    {
        Task<ILootTableModel> GetLootTable(int id);
        Task<ILootTableModel> GetLootTable(string name);
        Task<IList<ILootTableModel>> GetLootTables();
        Task<bool> UpdateLootTable(ILootTableModel lootTable);
        Task<bool> SaveLootTable(ILootTableModel lootTable);
        Task<bool> DeleteLootTable(ILootTableModel lootTable);
    }
}
