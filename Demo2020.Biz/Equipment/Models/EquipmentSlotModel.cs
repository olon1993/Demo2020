using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using GalaSoft.MvvmLight.Command;
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
        private IEquipmentModel _equipment;
        private string _multiplier;
        private int _index;

        public EquipmentSlotModel()
        {
            AddDescriptionCommand = new RelayCommand(AddDescription);
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

        public string Multiplier
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

        public ICommand AddDescriptionCommand { get; set; }
    }
}
