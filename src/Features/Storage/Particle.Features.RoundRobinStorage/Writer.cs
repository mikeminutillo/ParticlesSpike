using System.Linq;
using Particle.Core;
using Particle.Features.Audits;

namespace Particle.Features.RoundRobinStorage
{
    class Writer : AuditWriter
    {
        private readonly Store[] stores;
        private int index = -1;
        private readonly object lockObj = new object();

        public Writer(Core.Particle particle, RoundRobinStorageSettings settings)
        {
            stores = settings.Stores.Select(x => particle.Stores.Get(x)).ToArray();
        }

        public void WriteAudit(string audit)
        {
            GetNextStore().Get<AuditWriter>().WriteAudit(audit);
        }

        private Store GetNextStore()
        {
            lock (lockObj)
            {
                index = (index + 1) % stores.Length;
                return stores[index];
            }

        }
    }
}