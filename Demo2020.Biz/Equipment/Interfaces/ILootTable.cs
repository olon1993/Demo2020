using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ILootTable
    {
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        string ImageSource { get; set; }
        int LootTableSize { get; set; }
        IList<IEquipmentSlot> EquipmentSlots { get; set; }

    }
}
