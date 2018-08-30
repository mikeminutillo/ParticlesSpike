using System.Collections.Generic;
using System.Linq;
using Particle.Features.MessagesApi;

namespace Particle.Features.RemoteStorage
{
    class RemoteAuditor : MessagesQuery
    {
        public RemoteAuditor(RemoteStoreConnectionSettings storeConnection)
        {
            this.storeConnection = storeConnection;
        }

        private readonly RemoteStoreConnectionSettings storeConnection;

        // Fake getting audits from a remote source
        public IEnumerable<string> GetAllMessages() => from i in Enumerable.Range(1, 2)
            select $"Audit {i} from remote {storeConnection.ConnectionString}";
    }
}