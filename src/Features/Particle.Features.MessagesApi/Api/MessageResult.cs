namespace Particle.Features.MessagesApi
{
    class MessageResult
    {
        public string Store { get; set; }
        public string Message { get; set; }

        public override string ToString() => $"{Store}: {Message}";
    }
}
