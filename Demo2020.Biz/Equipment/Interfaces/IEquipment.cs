using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipment
    {
        string Index { get; set; }

        string Name { get; set; }

        ICategory EquipmentCategory { get; set; }

        ICategory GearCategory { get; set; }

        ICost Cost { get; set; }

        long Weight { get; set; }

        string[] Description { get; set; }

        string Url { get; set; }

        bool IsDataComplete { get; set; }
    }
}
