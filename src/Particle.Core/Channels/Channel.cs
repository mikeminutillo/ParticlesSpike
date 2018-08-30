namespace Particle.Core
{
    public class Channel : IProvideServices
    {
        private readonly string name;
        private readonly ServiceProvider serviceProvider;

        public Channel(string name, ServiceProvider serviceProvider)
        {
            this.name = name;
            this.serviceProvider = serviceProvider;
        }

        public string Name => name;

        public TService Get<TService>() => serviceProvider.Get<TService>();

        public bool HasService<TService>() => serviceProvider.HasService<TService>();
    }
}