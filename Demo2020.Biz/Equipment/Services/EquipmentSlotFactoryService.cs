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
        private IEquipmentService _equipmentService;

        public EquipmentSlotFactoryService(ILifetimeScope scope, IEquipmentService equipmentService)
        {
            _scope = scope;
            _equipmentService = equipmentService;
        }

        public IEquipmentSlotModel GetEquipmentSlot()
        {
            return new EquipmentSlotModel(_equipmentService);
        }
    }
}
