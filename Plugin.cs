using Exiled.API.Features;
using Exiled.Events;

namespace fight
{
    public class Test : Plugin<Config>
    {
        public override string Author => "Sodi7ДЛ";
        public override string Name => "Fight";
        public override Version RequiredExiledVersion { get; } = new("6.0.0");
    }

    private void OnSendConsoleCommand(SendingConsoleCommandEventArgs ev)
    {
        if (ev.Name.ToLower() != "fight") return;
        var player = Player.Get.OrderBy(p => p.DistanceSqr(ev.Player)).FirstOrDefault();
        if (player == null) return;
        player.Hurt(Damage, ev.Player);
        ev.ReturnMessage = $"You have hitted {player.Nickname}.";
        return;
    }
}
