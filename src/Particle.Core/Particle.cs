using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Particle.Core
{
    public class Particle
    {
        public StoreLibrary Stores { get; set; }
        public InterfaceLibrary TransportInterfaces { get; set; }
        public ChannelLibrary Channels { get; set; }
        public IReadOnlyDictionary<string, Api> Api { get; set; }

        public async Task Start()
        {
            await Task.WhenAll(Stores.AllWithService<Startable>().Select(x => x.Service.Start()))
                .ConfigureAwait(false);

            await Task.WhenAll(Channels.AllWithService<Startable>().Select(x => x.Service.Start()))
                .ConfigureAwait(false);

            await Task.WhenAll(TransportInterfaces.AllWithService<Startable>().Select(x => x.Service.Start()))
                .ConfigureAwait(false);

            // TODO: Start the API

            // TODO: Start any other things that need it
        }

        public async Task Stop()
        {
            // TODO: Stop other things that need it

            // TODO: Stop the API

            await Task.WhenAll(TransportInterfaces.AllWithService<Stoppable>().Select(x => x.Service.Stop()))
                .ConfigureAwait(false);

            await Task.WhenAll(Channels.AllWithService<Stoppable>().Select(x => x.Service.Stop()))
                .ConfigureAwait(false);

            await Task.WhenAll(Stores.AllWithService<Stoppable>().Select(x => x.Service.Stop()))
                .ConfigureAwait(false);
        }
    }
}