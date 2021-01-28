using Autofac;
using Demo2020.Biz.MonsterManual.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.MonsterManual.Services
{
    public class SpeedFactory : ISpeedFactory
    {
        private ILifetimeScope _scope;

        public SpeedFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public ISpeed GetSpeed()
        {
            return _scope.Resolve<ISpeed>();
        }
    }
}
