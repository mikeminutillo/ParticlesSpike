using Particle.Core;

namespace Particle.Features.InMemoryTransport
{
    public class InMemoryTransportType : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            // A real transport would probably rely on NSB.Raw to do it's TransportBinder work
            feature.RegisterInterfaceType("In Memory")
                .For<InMemoryTransport>(builder => new InMemoryTransport())
                .For<TransportBinder>(builder => builder.Get<InMemoryTransport>());
        }
    }
}
