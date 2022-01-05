using Demo2020.Biz.Commons.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Demo2020.Biz.Equipment.Models
{
    public class MagicItemModel : ObservableObject, IMagicItemModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private bool _isDataComplete;
        private string _name;
        private IList<DescriptionModel> _description;
        private IList<string> _stringdescription;
        private ICategoryModel _equipmentCategory;

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

        public MagicItemModel()
        {
            Description = new List<DescriptionModel>();
            EquipmentCategory = new CategoryModel();
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
        public ICategoryModel EquipmentCategory
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

        public IList<DescriptionModel> Description
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
                    List<DescriptionModel> buffer = new List<DescriptionModel>();
                    foreach (string s in _stringdescription)
                    {
                        buffer.Add(new Models.DescriptionModel(s));
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
                if (EquipmentCategory.Name == "Armor")
                {
                    return _shieldIconPath;
                }
                else if (EquipmentCategory.Name == "Weapon")
                {
                    return _swordIconPath;
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
