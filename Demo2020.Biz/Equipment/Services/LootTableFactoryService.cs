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
        private IEquipmentService _equipmentService;

        public LootTableFactoryService(ILifetimeScope scope, IEquipmentService equipmentService)
        {
            _scope = scope;
            _equipmentService = equipmentService;
        }

        public ILootTableModel GetLootTable()
        {
            IEquipmentSlotModel equipmentSlotModel = new EquipmentSlotModel(_equipmentService);

            ILootTableModel lootTableModel = new LootTableModel();
            lootTableModel.EquipmentSlots = new List<IEquipmentSlotModel>();
            lootTableModel.Name = "Name";
            lootTableModel.Description = "Description";
            return lootTableModel;
        }
    }
}
