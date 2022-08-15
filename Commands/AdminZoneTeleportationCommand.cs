using System;
using CommandSystem;
using Exiled.API.Features;
using UnityEngine;

namespace AdminZoneTeleportation.Commands
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    public class AdminZoneTeleportationCommand : ICommand
    {
        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (arguments.Count == 0)
            {
                response = "First argument should be a player id";
                return false;
            }

            if (Player.TryGet(Int32.Parse(arguments.At(0)), out Player target))
            {
                if (Plugin.Instance.EventHandlers.PlayerPositions.ContainsKey(target))
                {
                    target.Position = Plugin.Instance.EventHandlers.PlayerPositions[target] + Vector3.up * 0.25f;
                    Plugin.Instance.EventHandlers.PlayerPositions.Remove(target);
                    response = $"Successfully player was returned to old position {target.Position}";
                }
                else
                {
                    Plugin.Instance.EventHandlers.PlayerPositions.Add(target, target.Position);
                    target.Position = Player.Get(sender).Position + Vector3.up * 0.25f;
                    response = $"Successfully teleported to position {target.Position}";
                }

                return true;
            }

            response = "Id is bad";
            return false;
        }

        public string Command { get; } = "tpas";
        public string[] Aliases { get; } = Array.Empty<string>();
        public string Description { get; } = "Teleport player here and teleport back";
    }
}