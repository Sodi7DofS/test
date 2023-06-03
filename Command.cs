using Exiled.API.Features;
using CommandSystem;
using MEC;
using System.Numerics;

namespace fight.command
{
    [CommandHandler(typeof(ClientCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    public class Command : ICommand
    {
        public string Command => "fight";
        public string Description => "Hit player in front of you";
        public string[] Aliases => Array.Empty<string>();
        public class Watcher : MonoBehaviour
        {
            public Player _watchingPlayer;

            public void FixedUpdate()
            {
                if (_watchingPlayer != null)
                {
                    var mainCam = Camera.main;
                    var ray = mainCam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        var hitPlayer = Player.Get(hit.transform.gameObject);
                        if (hitPlayer != null && hitPlayer.Id != _watchingPlayer.Id)
                        {
                            Log.Info($"{_watchingPlayer.Nickname} is watching {hitPlayer.Nickname}");
                        }
                    }
                }
            }
        }
    }
}
