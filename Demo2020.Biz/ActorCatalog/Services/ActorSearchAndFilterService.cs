using Demo2020.Biz.ActorCatalog.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2020.Biz.ActorCatalog.Services
{
    public class ActorSearchAndFilterService : IActorSearchAndFilterService
    {
        public IList<IActorModel> Filter(IList<IActorModel> list, string filter)
        {
            IList<IActorModel> results = new List<IActorModel>();
            foreach (IActorModel actor in list)
            {
                string buffer = actor.Name.ToLower();
                if (buffer.Contains(filter.ToLower()))
                {
                    results.Add(actor);
                }
            }

            return results;
        }
    }
}
