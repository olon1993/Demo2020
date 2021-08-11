using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentSlot
    {
        IEquipment Equipment { get; set; }
        string Multiplier { get; set; }
    }
}
