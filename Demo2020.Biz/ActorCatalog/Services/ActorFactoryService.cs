using Autofac;
using Demo2020.Biz.ActorCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.ActorCatalog.Services
{
    public class ActorFactoryService : IActorFactoryService
    {
        private ILifetimeScope _scope;

        public ActorFactoryService(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IActorModel GetActor()
        {
            return _scope.Resolve<IActorModel>();
        }
    }
}
