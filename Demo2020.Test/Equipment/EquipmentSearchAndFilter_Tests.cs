using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Services;
using Demo2020.Biz.Equipment.Models;
using System.Collections.Generic;
using Xunit;

namespace Demo2020.Test.Equipment
{
    public class EquipmentSearchAndFilter_Tests
    {
        [Fact]
        public void Filter_OneResult_Test()
        {
            EquipmentSearchAndFilterService equipmentFilterService = new EquipmentSearchAndFilterService();
            IList<IEquipment> equipment = new List<IEquipment>
            {
                new Biz.Equipment.Models.Equipment { Name = "Small Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Hand Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Throwing Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Large Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Great Axe" },
            };
            string filter = "Throwing";

            IList<IEquipment> results = equipmentFilterService.Filter(equipment, filter);

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_ManyResults_Test()
        {
            EquipmentSearchAndFilterService equipmentFilterService = new EquipmentSearchAndFilterService();
            IList<IEquipment> equipment = new List<IEquipment>
            {
                new Biz.Equipment.Models.Equipment { Name = "Small Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Hand Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Throwing Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Large Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Great Axe" },
            };
            string filter = "Axe";

            IList<IEquipment> results = equipmentFilterService.Filter(equipment, filter);

            Assert.Equal(5, results.Count);
        }

        [Fact]
        public void Filter_NoResults_Test()
        {
            EquipmentSearchAndFilterService equipmentFilterService = new EquipmentSearchAndFilterService();
            IList<IEquipment> equipment = new List<IEquipment>
            {
                new Biz.Equipment.Models.Equipment { Name = "Small Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Hand Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Throwing Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Large Axe" },
                new Biz.Equipment.Models.Equipment { Name = "Great Axe" },
            };
            string filter = "Sword";

            IList<IEquipment> results = equipmentFilterService.Filter(equipment, filter);

            Assert.Equal(0, results.Count);
        }
    }
}
