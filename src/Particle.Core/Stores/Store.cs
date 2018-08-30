namespace Particle.Core
{
    public class Store : IProvideServices
    {
        private readonly ServiceProvider serviceProvider;
        private readonly string name;

        public Store(string name, ServiceProvider serviceProvider)
        {
            this.name = name;
            this.serviceProvider = serviceProvider;
        }

        public string Name => name;

        public TService Get<TService>() => serviceProvider.Get<TService>();

        public bool HasService<TService>() => serviceProvider.HasService<TService>();
    }
}
