namespace Particle.Core
{
    public struct ProvidedService<TProvider, TService> where TService : class
    {
        public TProvider Provider { get; set; }
        public TService Service { get; set; }
    }
}