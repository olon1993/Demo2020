using Demo2020.Biz.Equipment.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class DamageModel : IDamageModel
    {
        public DamageModel()
        {
            DamageType = new CategoryModel();
        }

        [JsonProperty("damage_dice")]
        public string DamageDice { get; set; }

        [JsonProperty("damage_type")]
        public ICategoryModel DamageType { get; set; }
    }
}
