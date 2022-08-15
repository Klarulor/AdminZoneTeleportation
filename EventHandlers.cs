using System;
using System.Collections.Generic;
using System.Text;
using Exiled.API.Features;
using UnityEngine;

namespace AdminZoneTeleportation
{
    internal class EventHandlers
    {
        internal readonly Dictionary<Player, Vector3> PlayerPositions = new Dictionary<Player, Vector3>(); 
        internal void OnWaitingForPlayers() => PlayerPositions.Clear();
    }
}
