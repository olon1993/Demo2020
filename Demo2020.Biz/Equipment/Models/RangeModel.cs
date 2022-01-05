using Demo2020.Biz.Equipment.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Models
{
    public class RangeModel : IRangeModel
    {
        [JsonProperty("normal")]
        public int? Normal { get; set; }

        [JsonProperty("long")]
        public int? Long { get; set; }
    }
}
