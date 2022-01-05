using Autofac;
using Demo2020.Biz.MonsterManual.Interfaces;
using Demo2020.Biz.MonsterManual.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class MonsterFactoryService : IMonsterFactoryService
    {
        private ILifetimeScope _scope;
        private ISpeedFactoryService _speedFactory;

        public MonsterFactoryService(ILifetimeScope scope, ISpeedFactoryService speedFactory)
        {
            _scope = scope;
            _speedFactory = speedFactory;
        }

        public IMonsterModel GetMonster()
        {
            return _scope.Resolve<IMonsterModel>();
        }
    }
}
