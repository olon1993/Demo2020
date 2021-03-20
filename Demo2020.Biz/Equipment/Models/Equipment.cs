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

        public Equipment()
        {
            EquipmentCategory = new Category();
            GearCategory = new Category();
            Cost = new Cost();
        }

        //**************************************************\\
        //******************* Properties *******************\\
        //**************************************************\\
        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("equipment_category")]
        public ICategory EquipmentCategory { get; set; }

        [JsonProperty("gear_category")]
        public ICategory GearCategory { get; set; }

        [JsonProperty("cost")]
        public ICost Cost { get; set; }

        [JsonProperty("weight")]
        public long Weight { get; set; }

        [JsonProperty("desc")]
        public string[] Description { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        public bool IsDataComplete
        {
            get { return _isDataComplete; }
            set { _isDataComplete = value; }
        }
    }
}
