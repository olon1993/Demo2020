using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;

namespace Demo2020.Biz.Equipment.Models
{
    public class LootTableModel : ObservableObject, ILootTableModel
    {
        //**************************************************\\
        //********************* Fields *********************\\
        //**************************************************\\
        private Guid _id;
        private string _name;
        private string _description;
        private string _imageSource;
        private int _lootTableSize;
        private IList<IEquipmentSlotModel> _equipmentSlots;

        public LootTableModel()
        {
            EquipmentSlots = new List<IEquipmentSlotModel>();
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        public Guid Id
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

        public IList<IEquipmentSlotModel> EquipmentSlots
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
