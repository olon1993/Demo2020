using Demo2020.Biz.ActorCatalog.Interfaces;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.MonsterManual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.ActorCatalog.Models
{
    public class Actor : ObservableObject, IActor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IMonster StatBlock { get; set; }
    }
}
