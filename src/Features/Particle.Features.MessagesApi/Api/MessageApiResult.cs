using System;
using System.Linq;

namespace Particle.Features.MessagesApi
{
    class MessageApiResult
    {
        public MessageResult[] Results { get; set; }

        public override string ToString() => string.Join(Environment.NewLine, Results.Select(x => x.ToString()));
    }
}