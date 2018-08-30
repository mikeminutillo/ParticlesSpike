namespace Particle.Core
{
    public class ChannelSettings
    {
        public string Interface { get; set; }
        public string PhysicalAddress { get; set; }
        public string ForwardingAddress { get; set; }

        // TODO: Add more advanced details in here like max concurrency
    }
}