using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.Equipment.Interfaces;

namespace Demo2020.Biz.ActorCatalog.Interfaces
{
    public interface IActorModel
    {
        string Name { get; set; }
        string Description { get; set; }
        IMonsterModel StatBlock { get; set; }
        int LootTableId { get; set; }
        ILootTableModel LootTable { get; set; }
    }
}
