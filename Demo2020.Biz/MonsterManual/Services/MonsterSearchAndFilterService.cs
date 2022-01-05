using Demo2020.Biz.MonsterManual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class MonsterSearchAndFilterService : IMonsterSearchAndFilterService
    {
        public IList<IMonsterModel> Filter(IList<IMonsterModel> list, string filter)
        {
            IList < IMonsterModel > results = new List<IMonsterModel>();
            foreach (IMonsterModel monster in list)
            {
                string buffer = monster.Name.ToLower();
                if (buffer.Contains(filter.ToLower()))
                {
                    results.Add(monster);
                }
            }

            return results;
            
        }
    }
}
