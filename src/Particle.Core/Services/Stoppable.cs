using System.Threading.Tasks;

namespace Particle.Core
{
    public interface Stoppable
    {
        Task Stop();
    }
}