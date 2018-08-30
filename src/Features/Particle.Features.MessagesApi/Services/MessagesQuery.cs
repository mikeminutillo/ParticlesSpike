using System.Collections.Generic;

namespace Particle.Features.MessagesApi
{
    public interface MessagesQuery
    {
        IEnumerable<string> GetAllMessages();
    }
}