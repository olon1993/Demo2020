using Demo2020.Biz.MonsterManual.Interfaces;

namespace Demo2020.Biz.ActorCatalog.Interfaces
{
    public interface IActorModel
    {
        string Name { get; set; }
        string Description { get; set; }
        IMonsterModel StatBlock { get; set; }
    }
}
