namespace Particle.Core
{
    public class ChannelLibrary : Library<Channel>
    {
        public ChannelLibrary(ServiceProviderBuilder[] channelBuilders) : base(channelBuilders) { }

        protected override Channel CreateNew(string name, ServiceProvider serviceProvider)
        {
            return new Channel(name, serviceProvider);
        }
    }
}