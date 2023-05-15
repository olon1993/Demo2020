using Demo2020.Biz.Commons.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ILootTableModel 
    {
        string Name { get; set; }
        int Id { get; set; }
        string Description { get; set; }
        string ImageSource { get; set; }
        int LootTableSize { get; set; }
        IList<IEquipmentSlotModel> EquipmentSlots { get; set; }
        bool IsDataComplete { get; set; }

    }
}
