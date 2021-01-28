using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class Speed : ObservableObject, ISpeed
    {
        private string _type;
        private int _value;

        public string Type
        {
            get { return _type; }
            set 
            { 
                if(_type != value)
                {
                    _type = value;
                    OnPropertyChanged();
                }
            }
        }

        public int Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged();
                }
            }
        }


    }
}
