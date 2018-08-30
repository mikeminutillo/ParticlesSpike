using System;
using System.Collections.Generic;
using System.Linq;

namespace Particle.Core
{
    public abstract class Library<TEntity> where TEntity : IProvideServices
    {
        private readonly IDictionary<string, TEntity> entities = new Dictionary<string, TEntity>();
        private readonly IDictionary<string, ServiceProviderBuilder> entityTypes;

        protected Library(params ServiceProviderBuilder[] entityTypes)
        {
            this.entityTypes = entityTypes.ToDictionary(t => t.Name);
        }

        public TEntity Get(string name) => entities[name];

        public IEnumerable<TEntity> All => entities.Values;

        public IEnumerable<ProvidedService<TEntity, TService>> AllWithService<TService>()
            where TService : class
            => from entity in entities.Values
                where entity.HasService<TService>()
                select new ProvidedService<TEntity, TService>
                {
                    Provider = entity,
                    Service = entity.Get<TService>()
                };

        public void Add(string name, string type, params object[] data)
        {
            if (!entityTypes.ContainsKey(type)) throw new InvalidOperationException($"Attempt to create {name} of type {type} but {type} was not found");
            var serviceProvider = entityTypes[type].Build(data);
            var entity = CreateNew(name, serviceProvider);
            entities[name] = entity;
        }

        protected abstract TEntity CreateNew(string name, ServiceProvider serviceProvider);
    }
}