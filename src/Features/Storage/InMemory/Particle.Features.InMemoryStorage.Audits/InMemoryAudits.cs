using Particle.Core;
using Particle.Features.Audits;
using Particle.Features.MessagesApi;

namespace Particle.Features.InMemoryStorage.Audits
{
    public class InMemoryAudits : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            // This provides the audit services over the top of the the in-memory storage
            // By doing it this way, this assembly only contains the details specifically
            // Required for this exact cross-section of features

            feature.RegisterStoreType("In Memory")
                .For<InMemoryAuditor>(builder => new InMemoryAuditor(builder.Get<InMemoryStorage>()))
                .For<MessagesQuery>(builder => builder.Get<InMemoryAuditor>())
                .For<AuditWriter>(builder => builder.Get<InMemoryAuditor>());
        }
    }
}
