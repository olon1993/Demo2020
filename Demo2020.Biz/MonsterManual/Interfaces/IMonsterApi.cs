using Demo2020.Biz.MonsterManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Interfaces
{
    public interface IMonsterApi
    {
        Task<List<Monster>> GetAllMonsters();
        Task<Monster> GetMonster(string name);
    }
}
