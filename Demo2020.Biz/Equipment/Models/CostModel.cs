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
    public class CostModel : ObservableObject, ICostModel
    {
        private long _quantity;
        private string _unit;
        private List<string> _unitTypes = new List<string> { "cp", "sp", "gp", "pp", "ep" };

        [JsonProperty("quantity")]
        public long Quantity
        {
            get { return _quantity; }
            set
            {
                if (_quantity != value)
                {
                    _quantity = value;
                    OnPropertyChanged();
                }
            }
        }

        [JsonProperty("unit")]
        public string Unit
        {
            get { return _unit; }
            set
            {
                if (_unit != value)
                {
                    _unit = value;
                    OnPropertyChanged();
                }
            }
        }

        public List<string> UnitTypes 
        {
            get { return _unitTypes; }
            set
            {
                if(_unitTypes != value)
                {
                    _unitTypes = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
