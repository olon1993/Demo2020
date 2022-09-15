using Autofac;
using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Interfaces;
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
            return _scope.Resolve<IEquipmentModel>();
            //IEquipmentModel equipmentModel = _scope.Resolve<IEquipmentModel>();
            //equipmentModel.Name = "Name";
            //equipmentModel.Description = new List<DescriptionModel> { new DescriptionModel("Description") };
            //return equipmentModel;
        }
    }
}
