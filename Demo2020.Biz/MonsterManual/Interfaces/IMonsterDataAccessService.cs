using Demo2020.Biz.MonsterManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface IMonsterDataAccessService
    {
        Task<List<MonsterModel>> GetAllMonsters();
        Task<MonsterModel> GetMonster(string name);
    }
}
