using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events;
using static fight.command.Command;

namespace fight
{
    public class Fight : Plugin<Config>
    {
        public override string Author => "Sodi7ДЛ";
        public override string Name => "Fight";
        public override Version RequiredExiledVersion { get; } = new("6.0.0");

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Server.SendingConsoleCommand += OnSendConsoleCommand;
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.SendingConsoleCommand -= OnSendConsoleCommand;
        }
    }



    private void OnSendConsoleCommand(SendingConsoleCommandEventArgs ev)
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!(sender is PlayerCommandSender))
            {
                response = "Only players can use this command";
                return false;
            }
            if (Watcher.hitPlayer == null)
            {
                response = "You don`t watch on player";
                return false;
            }
            int dmg = Config.Damage;
            Watcher.hitPlayer.Hurt(dmg, DamageTypes.Physics);
            response = "You have hitted somebody";
            return true;
        }
    }
}
