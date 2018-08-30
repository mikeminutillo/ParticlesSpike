namespace Particle.Features.Audits
{
    public interface AuditWriter
    {
        void WriteAudit(string audit);
    }
}