using System;
using System.Linq;
using Exiled.API.Features;

namespace AutoFFToggleReborn
{
    public class AutoFfToggleReborn : Plugin<Config>
    {
        public static AutoFfToggleReborn Instance { get; set; }
        public override string Name => nameof(AutoFfToggleReborn);
        public override string Author => "Kognity & Bezpa/Starlight";

        public override Version Version => new Version(2, 0, 0);

        public EventHandler Handler;

        public AutoFfToggleReborn()
        {
            Instance = this;
        }

        public override void OnEnabled()
        {
            if (Server.FriendlyFire)
            {
                Log.Info("Friendly Fire is already enabled on this server. AutoFFToggle will now be disabled.");
                Config.IsEnabled = false;

                return;
            }

            base.OnEnabled();
            Log.Info("Thank you for installing my plugin <3 - Kognity");

            Handler = new EventHandler();
            Exiled.Events.Handlers.Server.RoundStarted += Handler.OnRoundStartEvent;
            Exiled.Events.Handlers.Server.EndingRound += Handler.OnEndingRoundEvent;
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundStarted -= Handler.OnRoundStartEvent;
            Exiled.Events.Handlers.Server.EndingRound -= Handler.OnEndingRoundEvent;

            base.OnDisabled();
            Handler = null;
        }
    }
}