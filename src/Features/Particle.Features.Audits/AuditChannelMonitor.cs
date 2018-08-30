using System.Threading.Tasks;
using Particle.Core;

namespace Particle.Features.Audits
{
    class AuditChannelMonitor : Startable
    {
        private readonly Core.Particle particle;
        private readonly ChannelSettings channelSettings;
        private readonly AuditSettings auditSettings;

        public AuditChannelMonitor(Core.Particle particle, ChannelSettings channelSettings, AuditSettings auditSettings)
        {
            this.particle = particle;
            this.channelSettings = channelSettings;
            this.auditSettings = auditSettings;
        }

        public Task Start()
        {
            var store = particle.Stores.Get(auditSettings.Store);
            var auditIngestor = new AuditIngestor(store);
            particle.BindToTransport(auditIngestor.OnMessage, channelSettings);
            return Task.CompletedTask;
        }
    }
}