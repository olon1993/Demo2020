using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentPropertyModel
    {
        string Index { get; set; }

        string Name { get; set; }

        string[] Desc { get; set; }

        string Url { get; set; }
    }
}
