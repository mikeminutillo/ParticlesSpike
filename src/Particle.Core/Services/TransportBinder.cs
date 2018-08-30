using System;

namespace Particle.Core
{
    public interface TransportBinder
    {
        void Bind(string physicalAddress, Action<string> onMessage);
    }
}