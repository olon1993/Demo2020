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
    public class MonsterFactory : IMonsterFactory
    {
        private ILifetimeScope _scope;
        private ISpeedFactory _speedFactory;

        public MonsterFactory(ILifetimeScope scope, ISpeedFactory speedFactory)
        {
            _scope = scope;
            _speedFactory = speedFactory;
        }

        public IMonster GetMonster()
        {
            return _scope.Resolve<IMonster>();
        }
    }
}
