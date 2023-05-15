using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Demo2020.Biz.Equipment.Models
{
    public class EquipmentSlotModel : ObservableObject, IEquipmentSlotModel
    {
        private int _id;
        private int _lootTableId;
        private IEquipmentModel _equipment;
        private int _multiplier;
        private int _index;

        public EquipmentSlotModel()
        {
            AddDescriptionCommand = new RelayCommand(AddDescription);
            RemoveCommand = new RelayCommand(Remove);
            Equipment = new EquipmentModel();
        }

        public IEquipmentModel Equipment
        {
            get { return _equipment; }
            set
            {
                if (_equipment != value)
                {
                    _equipment = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Multiplier
        {
            get { return _multiplier; }
            set
            {
                if (_multiplier != value)
                {
                    _multiplier = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Index
        {
            get { return _index; }
            set
            {
                if(_index != value)
                {
                    _index = value;
                    OnPropertyChanged();
                }
            }
        }

        private void AddDescription()
        {
            IList<DescriptionModel> descriptions = new List<DescriptionModel>();
            foreach(DescriptionModel d in Equipment.Description)
            {
                descriptions.Add(d);
            }

            descriptions.Add(new DescriptionModel("{{New Line}}"));
            Equipment.Description = descriptions;
        }

        private void Remove()
        {
            Messenger.Default.Send(this);
        }

        public ICommand AddDescriptionCommand { get; set; }

        public ICommand RemoveCommand { get; set; }

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

        public int LootTableId
        {
            get { return _lootTableId; }
            set
            {
                if (_lootTableId != value)
                {
                    _lootTableId = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
