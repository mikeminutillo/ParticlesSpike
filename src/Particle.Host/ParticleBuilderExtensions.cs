using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Particle.Core;

namespace Particle.Host
{
    public static class ParticleBuilderExtensions
    {
        // Uses reflection to get all of the features in assemblies in the local folder and install them
        public static ParticleBuilder WithAllInstalledFeatures(this ParticleBuilder builder)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (var dll in Directory.GetFiles(path, "Particle.Features.*.dll"))
            {
                var assembly = Assembly.LoadFrom(dll);
                var featureDefinitions = assembly.GetTypes().Where(x =>
                    typeof(FeatureDefinition).IsAssignableFrom(x) && x.IsAbstract == false);
                foreach (var type in featureDefinitions)
                {
                    var feature = (FeatureDefinition) Activator.CreateInstance(type);
                    builder.With(feature);
                }
            }

            return builder;
        }
    }
}