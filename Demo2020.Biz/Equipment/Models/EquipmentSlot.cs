using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class EquipmentSlot : ObservableObject, IEquipmentSlot
    {
        private IEquipment _equipment;
        private string _multiplier;

        public IEquipment Equipment
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
    }
}
