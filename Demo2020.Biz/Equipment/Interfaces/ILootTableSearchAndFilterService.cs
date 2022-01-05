using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface ILootTableSearchAndFilterService
    {
        IList<ILootTableModel> Filter(IList<ILootTableModel> list, string filter);
    }
}
