using System.Collections.Generic;
using Particle.Features.Audits;
using Particle.Features.MessagesApi;

namespace Particle.Features.InMemoryStorage.Audits
{
    class InMemoryAuditor : AuditWriter, MessagesQuery
    {
        private readonly InMemoryStorage storage;

        public InMemoryAuditor(InMemoryStorage storage)
        {
            this.storage = storage;
            storage.Data["Audits"] = new List<string>();
        }

        public void WriteAudit(string message) => ((List<string>)storage.Data["Audits"]).Add(message);
        public IEnumerable<string> GetAllMessages() => (List<string>)storage.Data["Audits"];
    }
}