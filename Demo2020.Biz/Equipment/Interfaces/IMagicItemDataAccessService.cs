using Demo2020.Biz.Equipment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.Equipment.Interfaces
{
    public interface IMagicItemDataAccessService
    {
        Task<List<MagicItemModel>> GetAllMagicItems();
        Task<MagicItemModel> GetMagicItem(string name);
    }
}
