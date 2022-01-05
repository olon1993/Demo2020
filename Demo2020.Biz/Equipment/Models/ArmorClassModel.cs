using Demo2020.Biz.Equipment.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class ArmorClassModel : IArmorClassModel
    {
        [JsonProperty("base")]
        public int? Base { get; set; }

        [JsonProperty("dex_bonus")]
        public bool DexBonus { get; set; }

        [JsonProperty("max_bonus")]
        public int? MaxBonus { get; set; }
    }
}
