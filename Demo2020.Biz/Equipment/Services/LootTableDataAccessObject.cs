using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class LootTableDataAccessObject : ILootTableDataAccessObject
    {
        public Task<bool> DeleteLootTable(ILootTable lootTable)
        {
            throw new NotImplementedException();
        }

        public Task<ILootTable> GetLootTable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ILootTable> GetLootTable(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IList<ILootTable>> GetLootTables()
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveLootTable(ILootTable lootTable)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateLootTable(ILootTable lootTable)
        {
            throw new NotImplementedException();
        }
    }
}
