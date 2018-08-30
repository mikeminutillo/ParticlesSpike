using Particle.Core;

namespace Particle.Features.MessagesApi
{
    public class MessagesApiFeature : FeatureDefinition
    {
        public override void Install(ParticleDefinitionContext feature)
        {
            feature.RegisterApi<MessagesApi>("/messages");
        }
    }
}