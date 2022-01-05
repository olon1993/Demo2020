using Autofac;
using Demo2020.Biz.MonsterManual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class SpeedFactoryService : ISpeedFactoryService
    {
        private ILifetimeScope _scope;

        public SpeedFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ISpeedModel GetSpeed()
        {
            return _scope.Resolve<ISpeedModel>();
        }
    }
}
