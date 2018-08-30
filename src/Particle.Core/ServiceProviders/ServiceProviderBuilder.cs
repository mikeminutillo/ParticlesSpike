using System;
using System.Collections.Generic;
using System.Linq;

namespace Particle.Core
{
    public class ServiceProviderBuilder
    {
        private readonly List<Action<Dictionary<Type, Func<ServiceProvider, object>>>> fillIns = new List<Action<Dictionary<Type, Func<ServiceProvider, object>>>>();

        public string Name { get; }

        public ServiceProviderBuilder(string name)
        {
            Name = name;
        }

        public ServiceProviderBuilder For<TService>(Func<ServiceProvider, TService> factory) where TService : class
        {
            fillIns.Add(d => d[typeof(TService)] = factory);
            return this;
        }

        internal ServiceProvider Build(params object[] instances)
        {
            var instanceMap = instances.ToDictionary(o => o.GetType());

            var factories = new Dictionary<Type, Func<ServiceProvider, object>>();
            foreach (var fillIn in fillIns)
                fillIn(factories);

            return new ServiceProvider(instanceMap, factories);
        }
    }
}