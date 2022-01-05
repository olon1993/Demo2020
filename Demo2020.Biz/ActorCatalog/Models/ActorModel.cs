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
    public class ActorModel : ObservableObject, IActorModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IMonsterModel StatBlock { get; set; }
    }
}
