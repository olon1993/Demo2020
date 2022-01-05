using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using Demo2020.Biz.MonsterManual.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Demo2020.Test.MonsterManual
{
    public class MonsterSearchAndFilterService_Tests
    {
        [Fact]
        public void Filter_OneResult_Test()
        {
            MonsterSearchAndFilterService monsterFilterService = new MonsterSearchAndFilterService();
            IList<IMonsterModel> monsters = new List<IMonsterModel>
            {
                new MonsterModel { Name = "Red Dragon" },
                new MonsterModel { Name = "Blue Dragon" },
                new MonsterModel { Name = "Black Dragon" },
                new MonsterModel { Name = "White Dragon" },
                new MonsterModel { Name = "Green Dragon" },
            };
            string filter = "Red";

            IList<IMonsterModel> results = monsterFilterService.Filter(monsters, filter);

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_ManyResults_Test()
        {
            MonsterSearchAndFilterService monsterFilterService = new MonsterSearchAndFilterService();
            IList<IMonsterModel> monsters = new List<IMonsterModel>
            {
                new MonsterModel { Name = "Red Dragon" },
                new MonsterModel { Name = "Blue Dragon" },
                new MonsterModel { Name = "Black Dragon" },
                new MonsterModel { Name = "White Dragon" },
                new MonsterModel { Name = "Green Dragon" },
            };
            string filter = "Dragon";

            IList<IMonsterModel> results = monsterFilterService.Filter(monsters, filter);

            Assert.Equal(5, results.Count);
        }

        [Fact]
        public void Filter_NoResults_Test()
        {
            MonsterSearchAndFilterService monsterFilterService = new MonsterSearchAndFilterService();
            IList<IMonsterModel> monsters = new List<IMonsterModel>
            {
                new MonsterModel { Name = "Red Dragon" },
                new MonsterModel { Name = "Blue Dragon" },
                new MonsterModel { Name = "Black Dragon" },
                new MonsterModel { Name = "White Dragon" },
                new MonsterModel { Name = "Green Dragon" },
            };
            string filter = "Beholder";

            IList<IMonsterModel> results = monsterFilterService.Filter(monsters, filter);

            Assert.Equal(0, results.Count);
        }
    }
}
