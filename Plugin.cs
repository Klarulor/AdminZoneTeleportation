using Exiled.API.Enums;
using Exiled.API.Features;

namespace AdminZoneTeleportation
{
    public class Plugin : Plugin<Config>
    {
        public static Plugin Instance;
        internal EventHandlers EventHandlers = new EventHandlers();
        public override PluginPriority Priority { get; } = PluginPriority.Last;
        public Plugin() => Instance = this;
        public string PluginName => typeof(Plugin).Namespace;
        public override void OnEnabled()
        {
            RegisterEvents(); 
            Log.Info($"Plugin {PluginName} started");
        }
        public override void OnDisabled() => UnregisterEvents();
        private void RegisterEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers += EventHandlers.OnWaitingForPlayers;
        }
        private void UnregisterEvents()
        {
            Exiled.Events.Handlers.Server.WaitingForPlayers -= EventHandlers.OnWaitingForPlayers;
        }
    }
}
