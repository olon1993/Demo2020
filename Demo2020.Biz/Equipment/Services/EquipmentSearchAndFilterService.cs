using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentSearchAndFilterService : IEquipmentSearchAndFilterService
    {
        public IList<IEquipmentModel> Filter(IList<IEquipmentModel> list, string filter)
        {
            IList<IEquipmentModel> results = new List<IEquipmentModel>();
            foreach (IEquipmentModel equipment in list)
            {
                string buffer = equipment.Name.ToLower();
                if (buffer.Contains(filter.ToLower()))
                {
                    results.Add(equipment);
                }
            }

            return results;
        }
    }
}
