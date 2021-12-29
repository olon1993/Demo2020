using Demo2020.Biz.MonsterManual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class MonsterSearchAndFilterService : ISearchAndFilterService
    {
        public IList<IMonster> Filter(IList<IMonster> list, string filter)
        {
            IList < IMonster > results = new List<IMonster>();
            foreach (IMonster monster in list)
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
