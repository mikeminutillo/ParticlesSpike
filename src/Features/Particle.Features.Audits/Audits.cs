using Particle.Core;

namespace Particle.Features.Audits
{
    public class Audits : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            // Here we register a new channel type
            // It registers a startable that will bind to the configured transport
            // and push messages to the configured store
            feature.RegisterChannelType("Audits")
                .For<Startable>(builder => new AuditChannelMonitor(builder.Get<Core.Particle>(), builder.Get<ChannelSettings>(), builder.Get<AuditSettings>()));
        }
    }
}