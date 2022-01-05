using Xunit;
using Demo2020.Biz.Equipment.Services;
using System.Collections.Generic;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;

namespace Demo2020.Test.Equipment
{
    public class LootTableSearchAndFilterService_Tests
    {
        [Fact]
        public void Filter_OneResult_Test()
        {
            LootTableSearchAndFilterService lootTableFilterService = new LootTableSearchAndFilterService();
            IList<ILootTableModel> lootTables = new List<ILootTableModel>
            {
                new LootTableModel { Name = "Aboleth Loot" },
                new LootTableModel { Name = "Bandit Loot" },
                new LootTableModel { Name = "Chimera Loot" },
                new LootTableModel { Name = "Dinosaur Loot" },
                new LootTableModel { Name = "Elephant Loot" },
            };
            string filter = "Elephant";

            IList<ILootTableModel> results = lootTableFilterService.Filter(lootTables, filter);

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_ManyResults_Test()
        {
            LootTableSearchAndFilterService lootTableFilterService = new LootTableSearchAndFilterService();
            IList<ILootTableModel> lootTables = new List<ILootTableModel>
            {
                new LootTableModel { Name = "Aboleth Loot" },
                new LootTableModel { Name = "Bandit Loot" },
                new LootTableModel { Name = "Chimera Loot" },
                new LootTableModel { Name = "Dinosaur Loot" },
                new LootTableModel { Name = "Elephant Loot" },
            };
            string filter = "Loot";

            IList<ILootTableModel> results = lootTableFilterService.Filter(lootTables, filter);

            Assert.Equal(5, results.Count);
        }

        [Fact]
        public void Filter_NoResults_Test()
        {
            LootTableSearchAndFilterService lootTableFilterService = new LootTableSearchAndFilterService();
            IList<ILootTableModel> lootTables = new List<ILootTableModel>
            {
                new LootTableModel { Name = "Aboleth Loot" },
                new LootTableModel { Name = "Bandit Loot" },
                new LootTableModel { Name = "Chimera Loot" },
                new LootTableModel { Name = "Dinosaur Loot" },
                new LootTableModel { Name = "Elephant Loot" },
            };
            string filter = "Fighter";

            IList<ILootTableModel> results = lootTableFilterService.Filter(lootTables, filter);

            Assert.Equal(0, results.Count);
        }
    }
}
