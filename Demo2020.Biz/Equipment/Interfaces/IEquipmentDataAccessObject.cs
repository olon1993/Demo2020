using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo2020.Biz.Equipment.Models;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IEquipmentDataAccessObject
    {
        Task<List<Models.Equipment>> GetAllEquipment();
        Task<Models.Equipment> GetEquipment(string name);
    }
}
