using Demo2020.Biz.Commons.Models;
using Demo2020.Biz.Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IMagicItemModel
    {
        Guid Id { get; set; }

        string Name { get; set; }

        IList<DescriptionModel> Description { get; set; }

        ICategoryModel EquipmentCategory { get; set; }

        bool IsDataComplete { get; set; }
    }
}
