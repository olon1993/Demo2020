using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Services;
using Demo2020.Biz.Equipment.Models;
using System.Collections.Generic;
using Xunit;

namespace Demo2020.Test.Equipment
{
    public class EquipmentSearchAndFilterService_Tests
    {
        [Fact]
        public void Filter_OneResult_Test()
        {
            EquipmentSearchAndFilterService equipmentFilterService = new EquipmentSearchAndFilterService();
            IList<IEquipmentModel> equipment = new List<IEquipmentModel>
            {
                new Biz.Equipment.Models.EquipmentModel { Name = "Small Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Hand Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Throwing Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Large Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Great Axe" },
            };
            string filter = "Throwing";

            IList<IEquipmentModel> results = equipmentFilterService.Filter(equipment, filter);

            Assert.Equal(1, results.Count);
        }

        [Fact]
        public void Filter_ManyResults_Test()
        {
            EquipmentSearchAndFilterService equipmentFilterService = new EquipmentSearchAndFilterService();
            IList<IEquipmentModel> equipment = new List<IEquipmentModel>
            {
                new Biz.Equipment.Models.EquipmentModel { Name = "Small Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Hand Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Throwing Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Large Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Great Axe" },
            };
            string filter = "Axe";

            IList<IEquipmentModel> results = equipmentFilterService.Filter(equipment, filter);

            Assert.Equal(5, results.Count);
        }

        [Fact]
        public void Filter_NoResults_Test()
        {
            EquipmentSearchAndFilterService equipmentFilterService = new EquipmentSearchAndFilterService();
            IList<IEquipmentModel> equipment = new List<IEquipmentModel>
            {
                new Biz.Equipment.Models.EquipmentModel { Name = "Small Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Hand Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Throwing Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Large Axe" },
                new Biz.Equipment.Models.EquipmentModel { Name = "Great Axe" },
            };
            string filter = "Sword";

            IList<IEquipmentModel> results = equipmentFilterService.Filter(equipment, filter);

            Assert.Equal(0, results.Count);
        }
    }
}
