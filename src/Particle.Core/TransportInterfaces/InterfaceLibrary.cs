namespace Particle.Core
{
    public class InterfaceLibrary : Library<TransportInterface>
    {
        public InterfaceLibrary(ServiceProviderBuilder[] interfaceBuilders) : base(interfaceBuilders) { }

        protected override TransportInterface CreateNew(string name, ServiceProvider serviceProvider)
        {
            return new TransportInterface(name, serviceProvider);
        }
    }
}