using System.Linq;
using Particle.Core;

namespace Particle.Features.MessagesApi
{
    class MessagesApi : Api
    {
        public override object Get() => new MessageApiResult
        {
            Results = (from store in Particle.Stores.AllWithService<MessagesQuery>()
                    from message in store.Service.GetAllMessages()
                    select new MessageResult
                    {
                        Store = store.Provider.Name,
                        Message = message
                    }
                ).ToArray()
        };
    }
}