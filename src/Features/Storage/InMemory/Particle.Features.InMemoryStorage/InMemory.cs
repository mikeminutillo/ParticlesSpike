using Particle.Core;

namespace Particle.Features.InMemoryStorage
{
    public class InMemory : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            // This is the main feature for In Memory Storage
            // It sets things up and then other features can add their own implementations as needed
            // In theory, this could expose a Startable service if it needed to perform startup init

            feature.RegisterStoreType("In Memory")
                .For<InMemoryStorage>(builder => new InMemoryStorage());
        }
    }
}