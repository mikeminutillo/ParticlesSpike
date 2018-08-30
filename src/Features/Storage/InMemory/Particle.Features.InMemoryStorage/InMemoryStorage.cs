using System;
using System.Collections.Generic;

namespace Particle.Features.InMemoryStorage
{
    public class InMemoryStorage
    {
        public IDictionary<string, object> Data { get; } = new Dictionary<string, object>();
    }
}
