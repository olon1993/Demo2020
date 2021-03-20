using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IArmorClass
    {
        int? Base { get; set; }

        bool DexBonus { get; set; }

        int? MaxBonus { get; set; }
    }
}
