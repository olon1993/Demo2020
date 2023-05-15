using Autofac;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentSlotFactoryService : IEquipmentSlotFactoryService
    {
        private ILifetimeScope _scope;

        public EquipmentSlotFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IEquipmentSlotModel GetEquipmentSlot()
        {
            return new EquipmentSlotModel();
        }
    }
}
