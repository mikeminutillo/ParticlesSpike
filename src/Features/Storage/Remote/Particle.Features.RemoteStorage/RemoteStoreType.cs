using Particle.Core;
using Particle.Features.MessagesApi;

namespace Particle.Features.RemoteStorage
{
    public class RemoteStoreType : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            feature.RegisterStoreType("Remote")
                .For<MessagesQuery>(builder => new RemoteAuditor(builder.Get<RemoteStoreConnectionSettings>()));
        }
    }
}