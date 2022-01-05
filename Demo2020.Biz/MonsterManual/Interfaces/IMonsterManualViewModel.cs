using System.Collections.Generic;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface IMonsterManualViewModel
    {
        IMonsterModel CurrentMonster { get; set; }
        IList<IMonsterModel> Monsters { get; set; }
    }
}
