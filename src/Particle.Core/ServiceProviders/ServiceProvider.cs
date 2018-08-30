using System;
using System.Collections.Generic;

namespace Particle.Core
{
    public class ServiceProvider : IProvideServices
    {
        private readonly IDictionary<Type, object> instances;
        private readonly IDictionary<Type, Func<ServiceProvider, object>> factories;

        public ServiceProvider(IDictionary<Type, object> instances, IDictionary<Type, Func<ServiceProvider, object>> factories)
        {
            this.instances = instances;
            this.factories = factories;
        }

        internal void Add<TService>(TService instance)
        {
            instances[typeof(TService)] = instance;
        }

        public bool HasService<TService>() => instances.ContainsKey(typeof(TService)) || factories.ContainsKey(typeof(TService));

        public TService Get<TService>()
        {
            if (instances.TryGetValue(typeof(TService), out var service))
            {
                return (TService)service;
            }

            if (factories.TryGetValue(typeof(TService), out var factory))
            {
                var newService = factory(this);
                instances[typeof(TService)] = (object)newService;
                return (TService)newService;
            }

            throw new InvalidOperationException($"No provider for service: {typeof(TService)}");
        }
    }
}
