using System;
using System.Threading.Tasks;
using Particle.Core;
using Particle.Features.InMemoryTransport;

namespace Particle.Host
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The host decides where the config comes from
            var configProvider = new SampleParticleConfigProvider();
            //var configProvider = new RoundRobinSampleParticleConfigProvider();

            // The host also decides which features are available
            // Here we're just using reflection to load them all
            var particle = new ParticleBuilder(configProvider)
                .WithAllInstalledFeatures()
                .Build();

            // The host controls the particle lifecycle
            await particle.Start()
                .ConfigureAwait(false);

            FakeSomeAuditMessages(particle);

            FakeAQuery(particle);

            await particle.Stop()
                .ConfigureAwait(false);
        }

        private static void FakeSomeAuditMessages(Core.Particle particle)
        {
            // Note that a real transport wouldn't make its internals public to allow this
            var main = particle.TransportInterfaces.Get("Main");
            var transport = main.Get<InMemoryTransport>();
            var auditQ = transport.Get("audit");

            auditQ.Write("Hello");
            auditQ.Write("World");
            auditQ.Write("How are");
            auditQ.Write("You today?");
        }

        private static void FakeAQuery(Core.Particle particle)
        {
            // Aggregates all of the stores and returns unified results
            // Note that this would be mounted inside of Nancy / OWIN
            // And would probably be built with View Model Composition
            Console.WriteLine(particle.Api["/messages"].Get());
        }
    }
}
