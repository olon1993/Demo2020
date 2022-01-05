using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface IMonsterSearchAndFilterService
    {
        IList<IMonsterModel> Filter(IList<IMonsterModel> list, string filter);
    }
}
