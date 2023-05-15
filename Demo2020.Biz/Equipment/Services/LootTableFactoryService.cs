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
    public class LootTableFactoryService : ILootTableFactoryService
    {
        private ILifetimeScope _scope;

        public LootTableFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ILootTableModel GetLootTable()
        {
            IEquipmentSlotModel equipmentSlotModel = new EquipmentSlotModel();

            ILootTableModel lootTableModel = new LootTableModel();
            lootTableModel.EquipmentSlots = new List<IEquipmentSlotModel>();
            lootTableModel.Name = "Name";
            lootTableModel.Description = "Description";
            return lootTableModel;
        }
    }
}
