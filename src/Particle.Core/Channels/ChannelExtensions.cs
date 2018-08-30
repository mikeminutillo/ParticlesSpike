using System;

namespace Particle.Core
{
    public static class ChannelExtensions
    {
        public static void BindToTransport(this Particle particle, Action<string> onMessage,
            ChannelSettings channelSettings)
        {
            var transport = particle.TransportInterfaces.Get(channelSettings.Interface);
            var binder = transport.Get<TransportBinder>();
            // TODO: If the channel settings includes a forwarding address then wrap the OnMessage with a forwarding adapter
            binder.Bind(channelSettings.PhysicalAddress, onMessage);
        }
    }
}