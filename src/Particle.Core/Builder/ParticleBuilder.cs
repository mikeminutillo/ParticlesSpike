using System;

namespace Particle.Core
{
    public class ParticleBuilder
    {
        private readonly ParticleDefinitionContext context = new ParticleDefinitionContext();
        private readonly ParticleConfigProvider config;

        public ParticleBuilder(ParticleConfigProvider config = null)
        {
            this.config = config;
        }

        public ParticleBuilder With<TFeature>() where TFeature : FeatureDefinition, new()
        {
            return With(new TFeature());
        }

        public ParticleBuilder With(FeatureDefinition feature)
        {
            feature.Install(context);
            return this;
        }

        public Particle Build()
        {
            var particle = context.BuildUp();
            config?.ApplyTo(particle);
            return particle;
        }
    }
}