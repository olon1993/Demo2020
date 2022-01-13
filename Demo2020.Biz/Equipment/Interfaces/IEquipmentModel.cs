using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Models;
using System;
using System.Collections.Generic;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        double Weight { get; set; }

        IList<DescriptionModel> Description { get; set; }

        ICostModel Cost { get; set; }

        IDamageModel TwoHandedDamage { get; set; }

        IList<EquipmentPropertyModel> Properties { get; set; }

        IRangeModel Range { get; set; }

        IDamageModel Damage { get; set; }

        string CategoryRange { get; set; }

        string WeaponRange { get; set; }

        string WeaponCategory { get; set; }

        string ToolCategory { get; set; }

        string VehicleCategory { get; set; }

        string ArmorCategory { get; set; }

        ICategoryModel GearCategory { get; set; }

        ICategoryModel EquipmentCategory { get; set; }

        bool IsDataComplete { get; set; }
    }
}
