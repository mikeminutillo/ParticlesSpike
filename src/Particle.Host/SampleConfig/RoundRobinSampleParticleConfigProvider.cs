using Particle.Core;
using Particle.Features.Audits;
using Particle.Features.RoundRobinStorage;

namespace Particle.Host
{
    class RoundRobinSampleParticleConfigProvider : ParticleConfigProvider
    {
        public void ApplyTo(Core.Particle particle)
        {
            // Velma is a scaled out store running across 3 instances
            particle.Stores.Add(
                name: "Velma-1",
                type: "In Memory"
            );
            particle.Stores.Add(
                name: "Velma-2",
                type: "In Memory"
            );
            particle.Stores.Add(
                name: "Velma-3",
                type: "In Memory"
            );
            particle.Stores.Add(
                name: "Velma",
                type: "Round Robin",
                data: new RoundRobinStorageSettings { Stores = new[] { "Velma-1", "Velma-2", "Velma-3" } }
            );

            particle.TransportInterfaces.Add(
                name: "Main",
                type: "In Memory"
            );

            particle.Channels.Add(
                name: "Main Audit",
                type: "Audits",
                data: new object[]
                {
                    new ChannelSettings { Interface = "Main", PhysicalAddress = "audit" },
                    new AuditSettings { Store = "Velma" }
                });
        }
    }
}