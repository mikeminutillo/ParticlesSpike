using Particle.Core;
using Particle.Features.Audits;
using Particle.Features.RemoteStorage;

namespace Particle.Host
{
    class SampleParticleConfigProvider : ParticleConfigProvider
    {
        public void ApplyTo(Core.Particle particle)
        {
            // This is just a sample. We could be loading config from an external config file
            // Or reading it from a database somewhere

            // Each store has a unique name, a type, and possibly some other details it needs to do its job
            particle.Stores.Add(
                name: "Daphne",
                type: "In Memory"
            );

            particle.Stores.Add(
                name: "Scooby",
                type: "Remote",
                data: new RemoteStoreConnectionSettings { ConnectionString = "http://scooby:8080/api" }
            );
            particle.Stores.Add(
                name: "Shaggy",
                type: "Remote",
                data: new RemoteStoreConnectionSettings { ConnectionString = "http://shaggy:8080/api" }
            );

            // Each transport interface has a unique name, a type, and possibly some other details it needs to do its job
            particle.TransportInterfaces.Add(
                name: "Main",
                type: "In Memory"
            );
            // Note that there is absolutely no reason that single particle instance couldn't be connected to multiple transport interfaces

            // Each channel has a unique name, a type, and possibly some other details it needs to do its job
            particle.Channels.Add(
                name: "Main Audit",
                type: "Audits",
                data: new object[]
                {
                    new ChannelSettings { Interface = "Main", PhysicalAddress = "audit", ForwardingAddress = "audit.log" },
                    new AuditSettings { Store = "Daphne" }
                });
        }
    }
}