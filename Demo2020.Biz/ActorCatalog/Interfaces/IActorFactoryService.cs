using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.ActorCatalog.Interfaces
{
    public interface IActorFactoryService
    {
        IActorModel GetActor();
    }
}
