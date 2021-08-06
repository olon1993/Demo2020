using Demo2020.Biz.MonsterManual.Interfaces;

namespace Demo2020.Biz.ActorCatalog.Interfaces
{
    public interface IActor
    {
        string Name { get; set; }
        string Description { get; set; }
        IMonster StatBlock { get; set; }
    }
}
