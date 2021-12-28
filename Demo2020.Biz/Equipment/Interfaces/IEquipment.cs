using Demo2020.Biz.Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipment
    {
        
        string Name { get; set; }
        
        double Weight { get; set; }

        IList<Description> Description { get; set; }

        ICost Cost { get; set; }

        IDamage TwoHandedDamage { get; set; }

        IList<EquipmentProperty> Properties { get; set; }

        IRange Range { get; set; }

        IDamage Damage { get; set; }

        string CategoryRange { get; set; }

        string WeaponRange { get; set; }

        string WeaponCategory { get; set; }

        string ToolCategory { get; set; }

        string VehicleCategory { get; set; }

        ICategory GearCategory { get; set; }

        ICategory EquipmentCategory { get; set; }

        bool IsDataComplete { get; set; }
    }
}
