using Autofac;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentFactory : IEquipmentFactory
    {
        private ILifetimeScope _scope;

        public EquipmentFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IEquipment GetEquipment()
        {
            return _scope.Resolve<IEquipment>();
        }
    }
}
