using Demo2020.Biz.Commons.Models;
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
        private IList<Description> _description;
        private IList<string> _stringdescription;
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

        private string _armorIconPath = "/Demo2020;component/Resources/Images/ArmorIcon.png";
        private string _arrowsIconPath = "/Demo2020;component/Resources/Images/ArrowsIcon.png";
        private string _battleAxeIconPath = "/Demo2020;component/Resources/Images/BattleAxeIcon.png";
        private string _bowIconPath = "/Demo2020;component/Resources/Images/BowIcon.png";
        private string _crossbowIconPath = "/Demo2020;component/Resources/Images/CrossbowIcon.png";
        private string _daggerIconPath = "/Demo2020;component/Resources/Images/DaggerIcon.png";
        private string _hatchetIconPath = "/Demo2020;component/Resources/Images/HatchetIcon.png";
        private string _potionIconPath = "/Demo2020;component/Resources/Images/PotionIcon.png";
        private string _shieldIconPath = "/Demo2020;component/Resources/Images/ShieldIcon.png";
        private string _spearIconPath = "/Demo2020;component/Resources/Images/SpearIcon.png";
        private string _swordIconPath = "/Demo2020;component/Resources/Images/SwordIcon.png";
        private string _wandIconPath = "/Demo2020;component/Resources/Images/WandIcon.png";
        private string _warhammerIconPath = "/Demo2020;component/Resources/Images/WarhammerIcon.png";

        public Equipment()
        {
            Description = new List<Description>();
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

        public IList<Description> Description
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

        // This implementation is messy. I want to clean this up in the near future. 
        [JsonProperty("desc")]
        public IList<string> StringDescription
        {
            get { return _stringdescription; }
            set
            {
                if (_stringdescription != value)
                {
                    _stringdescription = value;
                    List<Description> buffer = new List<Description>();
                    foreach(string s in _stringdescription)
                    {
                        buffer.Add(new Models.Description(s));
                    }
                    Description = buffer;
                    OnPropertyChanged();
                }
            }
        }

        public string ImageSource
        {
            get 
            {
                if (EquipmentCategory.Name == "Armor" && ArmorCategory == "Shield")
                {
                    return _shieldIconPath;
                }
                else if (EquipmentCategory.Name == "Armor")
                {
                    return _armorIconPath;
                }
                else if (EquipmentCategory.Name == "Weapon" && WeaponRange == "Ranged")
                {
                    return _bowIconPath;
                }
                else if (EquipmentCategory.Name == "Weapon")
                {
                    return _swordIconPath;
                }
                else if(EquipmentCategory.Name == "Adventuring Gear" && GearCategory.Name == "Ammunition")
                {
                    return _arrowsIconPath;
                }
                else
                {
                    return _potionIconPath;
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
