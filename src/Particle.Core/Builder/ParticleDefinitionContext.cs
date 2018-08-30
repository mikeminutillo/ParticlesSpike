using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Particle.Core
{
    public class ParticleDefinitionContext
    {
        private readonly ConcurrentDictionary<string, ServiceProviderBuilder> storeProviders = new ConcurrentDictionary<string, ServiceProviderBuilder>();
        private readonly ConcurrentDictionary<string, ServiceProviderBuilder> interfaceProviders = new ConcurrentDictionary<string, ServiceProviderBuilder>();
        private readonly ConcurrentDictionary<string, ServiceProviderBuilder> channelProviders = new ConcurrentDictionary<string, ServiceProviderBuilder>();
        private readonly Dictionary<string, Api> apis = new Dictionary<string, Api>();

        public ServiceProviderBuilder RegisterStoreType(string name)
        {
            return storeProviders.GetOrAdd(name, n => new ServiceProviderBuilder(n));
        }

        public ServiceProviderBuilder RegisterInterfaceType(string name)
        {
            return interfaceProviders.GetOrAdd(name, n => new ServiceProviderBuilder(n));
        }

        public ServiceProviderBuilder RegisterChannelType(string name)
        {
            return channelProviders.GetOrAdd(name, n => new ServiceProviderBuilder(n));
        }

        public void RegisterApi<TApi>(string url) where TApi : Api, new()
        {
            apis.Add(url, new TApi());
        }

        public Particle BuildUp()
        {
            var particle = new Particle
            {
                Stores = new StoreLibrary(storeProviders.Values.ToArray()),
                TransportInterfaces = new InterfaceLibrary(interfaceProviders.Values.ToArray()),
                Channels = new ChannelLibrary(channelProviders.Values.ToArray()),
                Api = apis
            };

            foreach (var api in apis.Values)
                api.Particle = particle;
            foreach (var provider in storeProviders.Values)
                provider.For<Particle>(_ => particle);
            foreach (var provider in interfaceProviders.Values)
                provider.For<Particle>(_ => particle);
            foreach (var provider in channelProviders.Values)
                provider.For<Particle>(_ => particle);
            return particle;
        }
    }
}