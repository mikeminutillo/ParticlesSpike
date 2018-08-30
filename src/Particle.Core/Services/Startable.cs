using System.Threading.Tasks;

namespace Particle.Core
{
    public interface Startable
    {
        Task Start();
    }
}