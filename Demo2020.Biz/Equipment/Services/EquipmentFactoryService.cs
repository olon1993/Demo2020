using Autofac;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
using Demo2020.Biz.Equipment.Models;
using System.Collections.Generic;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentFactoryService : IEquipmentFactoryService
    {
        private ILifetimeScope _scope;

        public EquipmentFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IEquipmentModel GetEquipment()
        {
            //return _scope.Resolve<IEquipmentModel>();
            IEquipmentModel equipmentModel = new EquipmentModel();
            equipmentModel.Name = "Name";
            equipmentModel.Description.Add(new DescriptionModel("Description") );
            return equipmentModel;
        }
    }
}
