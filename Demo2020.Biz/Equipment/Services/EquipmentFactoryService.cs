using Autofac;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentFactoryService : IEquipmentFactoryService
    {
        private ILifetimeScope _scope;

        public EquipmentFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IEquipmentModel GetEquipment()
        {
            return _scope.Resolve<IEquipmentModel>();
        }
    }
}
