using Exiled.API.Features;

namespace SCPSLSeqLog
{
    public class Plugin : Plugin<Config>
    {
        public override string Author => "SirMeepington";

        public override string Name => "Sample Seq Logging Plugin";


        private EventHandler _events;

        public override void OnEnabled()
        {
            base.OnEnabled();

            _events = new EventHandler(this);

            Exiled.Events.Handlers.Player.Joined += _events.OnJoined;
            Exiled.Events.Handlers.Player.Left += _events.OnLeft;
            Exiled.Events.Handlers.Player.Died += _events.OnDied;

        }

        public override void OnDisabled()
        {
            base.OnDisabled();

            Exiled.Events.Handlers.Player.Joined -= _events.OnJoined;
            Exiled.Events.Handlers.Player.Left -= _events.OnLeft;
            Exiled.Events.Handlers.Player.Died -= _events.OnDied;


            _events = null;
        }

    }
}
