namespace AutoFFToggleReborn
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Server;
    using MEC;
	
    public class EventHandler
    {
        public void OnRoundStartEvent()
        {
            Server.FriendlyFire = false;
        }

        public void OnEndingRoundEvent(EndingRoundEventArgs ev)
        {
            Timing.CallDelayed(0.5f, () =>
            {
                Server.FriendlyFire = true;
            });
        }
    }
}