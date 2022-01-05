using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class LootTableDataAccessService : ILootTableDataAccessService
    {
        public Task<bool> DeleteLootTable(ILootTableModel lootTable)
        {
            throw new NotImplementedException();
        }

        public Task<ILootTableModel> GetLootTable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ILootTableModel> GetLootTable(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ILootTableModel>> GetLootTables()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveLootTable(ILootTableModel lootTable)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLootTable(ILootTableModel lootTable)
        {
            throw new NotImplementedException();
        }
    }
}
