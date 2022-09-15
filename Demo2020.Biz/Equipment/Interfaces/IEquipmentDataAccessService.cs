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
        Task<List<EquipmentModel>> GetAllEquipment();
        //IList<IEquipmentModel> GetAllEquipment();
        Task<EquipmentModel> GetEquipment(string name);
        IEquipmentModel GetEquipment(int id);
        IEquipmentModel GetEquipmentv2(string name);
        IList<IEquipmentModel> GetAllEquipmentv2();
        bool UpdateEquipment(IEquipmentModel equipment);
        bool UpdateEquipment(IList<IEquipmentModel> equipment);
        bool SaveEquipment(IEquipmentModel equipment);
        bool SaveEquipment(IList<IEquipmentModel> equipment);
        bool DeleteEquipment(IEquipmentModel equipment);
        bool DeleteEquipment(IList<IEquipmentModel> equipment);
    }
}
