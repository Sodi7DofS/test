using Exiled.API.Interfaces;

namespace fight
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public short Damage { get; set; } = 15;
    }
}
