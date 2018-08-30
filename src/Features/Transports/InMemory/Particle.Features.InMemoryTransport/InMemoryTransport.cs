using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Particle.Core;

namespace Particle.Features.InMemoryTransport
{
    public class InMemoryTransport : TransportBinder
    {
        private readonly ConcurrentDictionary<string, SyncQueue> bindings = new ConcurrentDictionary<string, SyncQueue>();

        public void Bind(string physicalAddress, Action<string> onMessage)
        {
            bindings.GetOrAdd(physicalAddress, a => new SyncQueue()).AddBinding(onMessage);
        }

        public ISendMessages Get(string name) => bindings.GetOrAdd(name, _ => new SyncQueue());

        class SyncQueue : ISendMessages
        {
            private readonly List<Action<string>> bindings = new List<Action<string>>();

            internal void AddBinding(Action<string> handler) => bindings.Add(handler);

            public void Write(string message)
            {
                bindings.ForEach(b => b.Invoke(message));
            }
        }
    }
}