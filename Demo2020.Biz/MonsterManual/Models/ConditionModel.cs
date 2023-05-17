using Demo2020.Biz.Commons.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class ConditionModel : ObservableObject
    {
        private string _name;
        private List<DescriptionModel> _description;

        public string Name
        {
            get { return _name; }
            set 
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        [JsonProperty("desc")]
        public List<DescriptionModel> Description
        {
            get { return _description; }
            set 
            {
                _description = value;
                OnPropertyChanged();
            }
        }

    }
}
