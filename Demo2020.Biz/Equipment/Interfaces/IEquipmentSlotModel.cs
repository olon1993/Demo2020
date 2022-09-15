using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentSlotModel
    {
        int Id { get; set; }
        IEquipmentModel Equipment { get; set; }
        int Multiplier { get; set; }
        int LootTableId { get; set; }
    }
}
