﻿using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class Equipment : ObservableObject, IEquipment
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private bool _isDataComplete;
        private string _name;
        private double _weight;
        private IList<string> _description;
        private ICost _cost;
        private IDamage _twoHandedDamage;
        private IList<EquipmentProperty> _properties;
        private IRange _range;
        private IDamage _damage;
        private string _categoryRange;
        private string _weaponRange;
        private string _weaponCategory;
        private string _toolCategory;
        private string _vehicleCategory;
        private ICategory _gearCategory;
        private ICategory _equipmentCategory;
        private bool _isStealthDisadvantage;
        private int _strengthRequirement;
        private IArmorClass _armorClass;
        private string _armorCategory;

        public Equipment()
        {
            Description = new List<string>();
            TwoHandedDamage = new Damage();
            Properties = new List<EquipmentProperty>();
            Range = new Range();
            Damage = new Damage();
            ArmorClass = new ArmorClass();
            EquipmentCategory = new Category();
            GearCategory = new Category();
            Cost = new Cost();
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\

        [JsonProperty("name")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("equipment_category")]
        public ICategory EquipmentCategory
        {
            get { return _equipmentCategory; }
            set
            {
                if (_equipmentCategory != value)
                {
                    _equipmentCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("gear_category")]
        public ICategory GearCategory
        {
            get { return _gearCategory; }
            set
            {
                if (_gearCategory != value)
                {
                    _gearCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("vehicle_category")]
        public string VehicleCategory
        {
            get { return _vehicleCategory; }
            set
            {
                if (_vehicleCategory != value)
                {
                    _vehicleCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("tool_category")]
        public string ToolCategory
        {
            get { return _toolCategory; }
            set
            {
                if (_toolCategory != value)
                {
                    _toolCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("weapon_category")]
        public string WeaponCategory
        {
            get { return _weaponCategory; }
            set
            {
                if (_weaponCategory != value)
                {
                    _weaponCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("weapon_range")]
        public string WeaponRange
        {
            get { return _weaponRange; }
            set
            {
                if (_weaponRange != value)
                {
                    _weaponRange = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("category_range")]
        public string CategoryRange
        {
            get { return _categoryRange; }
            set
            {
                if (_categoryRange != value)
                {
                    _categoryRange = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("damage")]
        public IDamage Damage
        {
            get { return _damage; }
            set
            {
                if (_damage != value)
                {
                    _damage = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("range")]
        public IRange Range
        {
            get { return _range; }
            set
            {
                if (_range != value)
                {
                    _range = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("properties")]
        public IList<EquipmentProperty> Properties
        {
            get { return _properties; }
            set
            {
                if (_properties != value)
                {
                    _properties = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("two_handed_damage")]
        public IDamage TwoHandedDamage
        {
            get { return _twoHandedDamage; }
            set
            {
                if (_twoHandedDamage != value)
                {
                    _twoHandedDamage = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("armor_category")]
        public string ArmorCategory
        {
            get { return _armorCategory; }
            set
            {
                if (_armorCategory != value)
                {
                    _armorCategory = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("armor_class")]
        public IArmorClass ArmorClass
        {
            get { return _armorClass; }
            set
            {
                if (_armorClass != value)
                {
                    _armorClass = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("str_minimum")]
        public int StrengthRequirement
        {
            get { return _strengthRequirement; }
            set
            {
                if (_strengthRequirement != value)
                {
                    _strengthRequirement = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("stealth_disadvantage")]
        public bool IsStealthDisadvantage
        {
            get { return _isStealthDisadvantage; }
            set
            {
                if (_isStealthDisadvantage != value)
                {
                    _isStealthDisadvantage = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("cost")]
        public ICost Cost
        {
            get { return _cost; }
            set
            {
                if (_cost != value)
                {
                    _cost = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("weight")]
        public double Weight
        {
            get { return _weight; }
            set
            {
                if (_weight != value)
                {
                    _weight = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("desc")]
        public IList<string> Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool IsDataComplete
        {
            get { return _isDataComplete; }
            set { _isDataComplete = value; }
        }
    }
}
