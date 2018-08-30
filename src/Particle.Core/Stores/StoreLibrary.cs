namespace Particle.Core
{
    public class StoreLibrary : Library<Store>
    {
        public StoreLibrary(ServiceProviderBuilder[] storeBuilders) : base(storeBuilders) { }

        protected override Store CreateNew(string name, ServiceProvider serviceProvider)
        {
            return new Store(name, serviceProvider);
        }
    }
}