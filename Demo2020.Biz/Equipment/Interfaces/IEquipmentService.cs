using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentService
    {
        Task<IList<IEquipmentModel>> GetAllEquipmentAsync();
        IList<IEquipmentModel> GetAllEquipment();
        Task<IEquipmentModel> GetEquipmentAsync(string name);
        IEquipmentModel GetEquipment();
        int SaveEquipment(IEquipmentModel equipmentModel);
        bool DeleteEquipment(IEquipmentModel equipmentModel);
        IList<IEquipmentModel> Filter(string filter);
        int AddEquipment();
        IList<IEquipmentModel> Equipment { get; set; }
    }
}
