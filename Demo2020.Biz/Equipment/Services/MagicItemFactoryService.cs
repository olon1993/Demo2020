using Autofac;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class MagicItemFactoryService : IMagicItemFactoryService
    {
        private ILifetimeScope _scope;

        public MagicItemFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IMagicItemModel GetMagicItem()
        {
            return _scope.Resolve<IMagicItemModel>();
        }
    }
}
