// плагин примерный,тк с exiled'ом не знаком, делал по тутору (версия exiled 2.0)
namespace TestPlugin
{
    using System;
    using Exiled.API.Features;
    using CommandSystem;
    using RemoteAdmin;

    public class Plugin : Plugin<Config>
    {
        public override string Name = "TestPlugin";
        public override string Author = "Sodi7ДЛ";
        public override Version Version = new Version(1, 0, 0);

        [CommandHandler(typeof(RemoteAdminCommandHandler))]

        public override void OnEnabled()
        {
            Log.Info("Plugin has been enabled");
        }

        public override void OnDisabled()
        {
            Log.Info("Plugin has been disabled");
        }
    }

    public class Config : IConfig
    {
        public bool IsEnabled { get; set; }
    }

    public class Command : ICommand
    {
        public string Command { get; } = "fight";
        public string[] Aliases { get; } = { "fight" };
        public string Description { get; } = "Команда для битья";

        public bool Execute(ArraySegment<string> arguments, IcommandSender sender, out string response)
        {
            Timing.CallDelayed(5f, () 
            {
                if (sender is PlayerCommandSender player and Player.IsCuffed == false) //не знаю как получить состояние рук игрока (связанны или нет), так что пусть будет так 
                {
                    response = $"Ударил";
                    PlayerB.hp -= 20; //в задании не сказано как мы получаем избиваемого игрока, поэтому эта строчка условна
                    return true;
                }
            })
        }
    }
}
