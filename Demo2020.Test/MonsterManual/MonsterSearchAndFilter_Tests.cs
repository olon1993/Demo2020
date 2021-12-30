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
    public class MonsterSearchAndFilter_Tests
    {
        [Fact]
        public void Filter_OneResult_Test()
        {
            MonsterSearchAndFilterService monsterFilterService = new MonsterSearchAndFilterService();
            IList<IMonster> monsters = new List<IMonster>
            {
                new Monster { Name = "Red Dragon" },
                new Monster { Name = "Blue Dragon" },
                new Monster { Name = "Black Dragon" },
                new Monster { Name = "White Dragon" },
                new Monster { Name = "Green Dragon" },
            };
            string filter = "Red";

            IList<IMonster> results = monsterFilterService.Filter(monsters, filter);

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_ManyResults_Test()
        {
            MonsterSearchAndFilterService monsterFilterService = new MonsterSearchAndFilterService();
            IList<IMonster> monsters = new List<IMonster>
            {
                new Monster { Name = "Red Dragon" },
                new Monster { Name = "Blue Dragon" },
                new Monster { Name = "Black Dragon" },
                new Monster { Name = "White Dragon" },
                new Monster { Name = "Green Dragon" },
            };
            string filter = "Dragon";

            IList<IMonster> results = monsterFilterService.Filter(monsters, filter);

            Assert.Equal(5, results.Count);
        }

        [Fact]
        public void Filter_NoResults_Test()
        {
            MonsterSearchAndFilterService monsterFilterService = new MonsterSearchAndFilterService();
            IList<IMonster> monsters = new List<IMonster>
            {
                new Monster { Name = "Red Dragon" },
                new Monster { Name = "Blue Dragon" },
                new Monster { Name = "Black Dragon" },
                new Monster { Name = "White Dragon" },
                new Monster { Name = "Green Dragon" },
            };
            string filter = "Beholder";

            IList<IMonster> results = monsterFilterService.Filter(monsters, filter);

            Assert.Equal(0, results.Count);
        }
    }
}
