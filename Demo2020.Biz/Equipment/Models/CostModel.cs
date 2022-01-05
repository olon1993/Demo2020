using Demo2020.Biz.Equipment.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class CostModel : ICostModel
    {
        [JsonProperty("quantity")]
        public long Quantity { get; set; }

        [JsonProperty("unit")]
        public string Unit { get; set; }
    }
}
