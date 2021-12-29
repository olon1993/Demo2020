using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class LootTable : ObservableObject, ILootTable
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private int _id;
        private string _name;
        private string _description;
        private string _imageSource;
        private int _lootTableSize;
        private IList<IEquipmentSlot> _equipmentSlots;

        public LootTable()
        {
            EquipmentSlots = new List<IEquipmentSlot>();
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public int Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

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

        public string Description
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

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        public int LootTableSize
        {
            get { return _lootTableSize; }
            set
            {
                if (_lootTableSize != value)
                {
                    _lootTableSize = value;
                    OnPropertyChanged();
                }
            }
        }

        public IList<IEquipmentSlot> EquipmentSlots
        {
            get { return _equipmentSlots; }
            set
            {
                if (_equipmentSlots != value)
                {
                    _equipmentSlots = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
