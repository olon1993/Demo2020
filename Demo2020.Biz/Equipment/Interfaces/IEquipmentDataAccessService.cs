using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo2020.Biz.Equipment.Models;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentDataAccessService
    {
        Task<List<EquipmentModel>> GetAllEquipmentAsync();
        Task<EquipmentModel> GetEquipmentAsync(string name);
        IEquipmentModel GetEquipment(int id);
        IEquipmentModel GetEquipment(string name);
        IList<IEquipmentModel> GetAllEquipment();
        int SaveEquipment(IEquipmentModel equipment);
        int SaveEquipment(IList<IEquipmentModel> equipment);
        bool DeleteEquipment(IEquipmentModel equipment);
        bool DeleteEquipment(IList<IEquipmentModel> equipment);
    }
}
