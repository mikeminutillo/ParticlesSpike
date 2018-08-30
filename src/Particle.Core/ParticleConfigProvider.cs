namespace Particle.Core
{
    public interface ParticleConfigProvider
    {
        void ApplyTo(Particle particle);
    }
}