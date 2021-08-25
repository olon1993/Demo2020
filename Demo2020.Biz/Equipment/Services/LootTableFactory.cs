using Autofac;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class LootTableFactory : ILootTableFactory
    {
        private ILifetimeScope _scope;

        public LootTableFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ILootTable GetLootTable()
        {
            return _scope.Resolve<ILootTable>();
        }
    }
}
