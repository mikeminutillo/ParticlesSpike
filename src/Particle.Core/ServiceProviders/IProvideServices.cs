namespace Particle.Core
{
    public interface IProvideServices
    {
        bool HasService<TService>();
        TService Get<TService>();
    }
}