using Xunit;
using Demo2020.Biz.Equipment.Services;
using System.Collections.Generic;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;

namespace Demo2020.Test.Equipment
{
    public class LootTableSearchAndFilter_Tests
    {
        [Fact]
        public void Filter_OneResult_Test()
        {
            LootTableSearchAndFilterService lootTableFilterService = new LootTableSearchAndFilterService();
            IList<ILootTable> lootTables = new List<ILootTable>
            {
                new LootTable { Name = "Aboleth Loot" },
                new LootTable { Name = "Bandit Loot" },
                new LootTable { Name = "Chimera Loot" },
                new LootTable { Name = "Dinosaur Loot" },
                new LootTable { Name = "Elephant Loot" },
            };
            string filter = "Elephant";

            IList<ILootTable> results = lootTableFilterService.Filter(lootTables, filter);

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_ManyResults_Test()
        {
            LootTableSearchAndFilterService lootTableFilterService = new LootTableSearchAndFilterService();
            IList<ILootTable> lootTables = new List<ILootTable>
            {
                new LootTable { Name = "Aboleth Loot" },
                new LootTable { Name = "Bandit Loot" },
                new LootTable { Name = "Chimera Loot" },
                new LootTable { Name = "Dinosaur Loot" },
                new LootTable { Name = "Elephant Loot" },
            };
            string filter = "Loot";

            IList<ILootTable> results = lootTableFilterService.Filter(lootTables, filter);

            Assert.Equal(5, results.Count);
        }

        [Fact]
        public void Filter_NoResults_Test()
        {
            LootTableSearchAndFilterService lootTableFilterService = new LootTableSearchAndFilterService();
            IList<ILootTable> lootTables = new List<ILootTable>
            {
                new LootTable { Name = "Aboleth Loot" },
                new LootTable { Name = "Bandit Loot" },
                new LootTable { Name = "Chimera Loot" },
                new LootTable { Name = "Dinosaur Loot" },
                new LootTable { Name = "Elephant Loot" },
            };
            string filter = "Fighter";

            IList<ILootTable> results = lootTableFilterService.Filter(lootTables, filter);

            Assert.Equal(0, results.Count);
        }
    }
}
