using System.Collections.Generic;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface IMonsterManualViewModel
    {
        IMonster CurrentMonster { get; set; }
        IList<IMonster> Monsters { get; set; }
    }
}
