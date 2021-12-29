using Demo2020.Biz.Equipment.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Services
{
    public class EquipmentSearchAndFilterService : IEquipmentSearchAndFilter
    {
        public IList<IEquipment> Filter(IList<IEquipment> list, string filter)
        {
            IList<IEquipment> results = new List<IEquipment>();
            foreach (IEquipment equipment in list)
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
