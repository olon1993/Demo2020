using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Models
{
    public class ProficiencyElementModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
