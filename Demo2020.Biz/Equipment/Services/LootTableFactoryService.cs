using Autofac;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class LootTableFactoryService : ILootTableFactoryService
    {
        private ILifetimeScope _scope;

        public LootTableFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ILootTableModel GetLootTable()
        {
            return _scope.Resolve<ILootTableModel>();
        }
    }
}
