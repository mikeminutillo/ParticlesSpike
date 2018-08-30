using Particle.Core;
using Particle.Features.Audits;

namespace Particle.Features.RoundRobinStorage
{
    public class RoundRobinStorage : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            // A basic round-robin audit store
            // Register a single writer that can be configured with a number of different stores
            //   And round-robin writes to them all.
            // No need to implement the query interface as all of the sub-stores will be queried anyway

            feature.RegisterStoreType("Round Robin")
                .For<AuditWriter>(builder => new Writer(builder.Get<Core.Particle>(), builder.Get<RoundRobinStorageSettings>()));
        }
    }
}
