using Particle.Core;

namespace Particle.Features.Audits
{
    class AuditIngestor
    {
        private readonly Store store;

        public AuditIngestor(Store store)
        {
            this.store = store;
        }

        public void OnMessage(string message)
        {
            // TODO: Metadata, etc.
            store.Get<AuditWriter>().WriteAudit(message);
        }
    }
}