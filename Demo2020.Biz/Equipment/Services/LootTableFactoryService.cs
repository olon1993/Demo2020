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
            IEquipmentSlotModel equipmentSlotModel = _scope.Resolve<IEquipmentSlotModel>();

            ILootTableModel lootTableModel = _scope.Resolve<ILootTableModel>();
            lootTableModel.EquipmentSlots = _scope.Resolve<IList<IEquipmentSlotModel>>();
            lootTableModel.EquipmentSlots.Add(equipmentSlotModel);
            lootTableModel.Name = "Name";
            lootTableModel.Description = "Description";
            return lootTableModel;
        }
    }
}
